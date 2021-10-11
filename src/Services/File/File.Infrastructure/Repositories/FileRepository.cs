using File.Domain.AggregatesModel;
using File.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileEntity = File.Domain.AggregatesModel.File;

namespace File.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public FileRepository(FileContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<FileEntity> GetAsync(string fileHash)
        {
            var result = await _context.Set<FileEntity>().FirstOrDefaultAsync(a => a.FileHash == fileHash);
            return result;
        }

        public FileEntity Add(FileEntity file)
        {
            return _context.Add(file).Entity;
        }

        public async Task<FileEntity> GetAsync(int id)
        {
            var result = await _context.Set<FileEntity>().FindAsync(id);
            return result;
        }
        public FileEntity Update(FileEntity file)
        {
            return _context.Update(file).Entity;
        }
    }
}
