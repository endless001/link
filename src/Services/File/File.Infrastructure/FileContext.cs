using System;
using File.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using File.Domain.AggregatesModel;
using File.Infrastructure.EntityConfigurations;
using FileEntity = File.Domain.AggregatesModel.File;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace File.Infrastructure
{
    public class FileContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "file";
    
        public DbSet<FileEntity> Files { get; set; }
        public DbSet<FileType> FileType { get; set; }
        public DbSet<FileStatus> FileStatus { get; set; }

        private readonly IMediator _mediator;

        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public FileContext(DbContextOptions<FileContext> options) : base(options) { }
        public FileContext(DbContextOptions<FileContext> options, IMediator mediator) :
         base(options)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("FileContext::ctor ->" + this.GetHashCode());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FileTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FileStatusEntityTypeConfiguration());

        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
