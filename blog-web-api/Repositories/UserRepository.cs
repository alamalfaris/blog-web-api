using blog_web_api.Database;
using blog_web_api.Interfaces;
using blog_web_api_shared.Entities;
using Dapper;

namespace blog_web_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            string query = $@"select 
                                id
                                ,name
                                ,email
                                ,created_date CreatedDate
                                from users";

            using (var db = _context.GetConnection())
            {
                var users = await db.QueryAsync<User>(query);
                return users.ToList();
            }
        }
    }
}
