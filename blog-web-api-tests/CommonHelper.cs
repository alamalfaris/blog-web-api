using blog_web_api.Database;
using blog_web_api_shared.DataTransferObjects;
using blog_web_api_shared.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_web_api_tests
{
    public static class CommonHelper
    {
        public static IOptions<ConnectionDb> GetConnectionDbOption()
        {
            var connectionDbOptions = Options.Create(new ConnectionDb
            {
                Host = "localhost",
                Port = 5432,
                Database = "blog-web-tests",
                Username = "postgres",
                Hash = "!suPer12@"
            });
            
            return connectionDbOptions;
        }

        public static DapperContext GetDapperContext()
        {
            return new DapperContext(GetConnectionDbOption());
        }

        public static List<User> GetExpectedUsers()
        {
            return new List<User> 
            { 
                new User { Id = "1aq2sw", Name = "User1" }, 
                new User { Id = "2sw3de", Name = "User2" } 
            };
        }
    }
}
