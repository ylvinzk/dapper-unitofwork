using DataAccess;
using DataAccess.Models;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OneRepository
    {
        private readonly DataBaseAccess dataBaseAccess;

        public OneRepository(DataBaseAccess dataBaseAccess)
        {
            this.dataBaseAccess = dataBaseAccess;
        }

        public async Task<SomeModel> GetAsync(int id)
        {
            const string sql =
                @"SELECT *
                FROM Table
                WHERE Id = @Id";
            var parameters = new { Id = id };

            return await dataBaseAccess.LoadFirstOrDefaultAsync<SomeModel, dynamic>(sql, parameters);
        }        
    }
}
