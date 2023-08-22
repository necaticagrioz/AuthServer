using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public static class SignService
    {
        public static SecurityKey GetSymmetricSecurtityKey(string securtityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securtityKey));
        }
    }
}
