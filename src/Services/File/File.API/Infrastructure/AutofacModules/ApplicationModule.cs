using Autofac;
using File.API.Application.Queries;
using File.API.Infrastructure.Idempotency;
using File.Domain.AggregatesModel;
using File.Infrastructure.Repositories;

namespace File.API.Infrastructure.AutofacModules
{
    public class ApplicationModule: Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new FileQueries(QueriesConnectionString))
                .As<IFileQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FileRepository>()
                .As<IFileRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<RequestManager>()
                .As<IRequestManager>()
                .InstancePerLifetimeScope();

        }
    }
}