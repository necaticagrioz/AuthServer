using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.DTO_s
{
    public class ClientLoginDTO
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
