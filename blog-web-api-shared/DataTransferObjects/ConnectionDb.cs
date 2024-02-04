using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_web_api_shared.DataTransferObjects
{
    public class ConnectionDb
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Database { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
    }
}
