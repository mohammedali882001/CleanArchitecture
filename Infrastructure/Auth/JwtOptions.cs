using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Auth
{
    public class JwtOptions
    {
        public string Issure { get; set; }
        public string Audiance { get; set; }
        public string ApiKey { get; set; }
        public int Time { get; set; }
    }
}
