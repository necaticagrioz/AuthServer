using AuthServer.Core.DTO_s;
using SharedLibrary.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDTO>> CreateUserAsync(CreateUserDTO createUserDTO);
        Task<Response<UserAppDTO>> GetUserByNameAsync(string userName);
    }
}
