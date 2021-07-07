using DataAccess;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Infrastructure.UnitsOfWork
{
    public class OneUnitOfWork : GenericUnitOfWork
    {
        public OneUnitOfWork(IConfiguration configuration)
            : base(new SqlConnection(configuration.GetConnectionString(nameof(ConnectionStringName.Default))))
        {
        }

        private OneRepository oneRepository;
        public OneRepository OneRepository =>
            oneRepository ??= new OneRepository(dataBaseAccess);

        private TwoRepository twoRepository;
        public TwoRepository TwoRepository =>
            twoRepository ??= new TwoRepository(dataBaseAccess);

        protected override void ResetRepositories()
        {
            oneRepository = null;
            twoRepository = null;            
        }
    }
}
