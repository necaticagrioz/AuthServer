﻿using AuthServer.Core.DTO_s;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthServer.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("CreateToken")]
        public async Task<IActionResult> CreateToken(LoginDTO loginDTO)
        {
            var result = await _authenticationService.CreateTokenAsync(loginDTO);
            return ActionResultInstance(result);
        }
        [HttpPost("CreateTokenByClient")]
        public IActionResult CreateTokenByClient(ClientLoginDTO clientLoginDTO)
        {
            var result = _authenticationService.CreateTokenByClient(clientLoginDTO);
            return ActionResultInstance(result);
        }
        [HttpPost("RevokeRefreshToken")]

        public async Task<IActionResult>RevokeRefreshToken(RefreshTokenDTO refreshTokenDTO)
        {

            var result = await _authenticationService.RevokeRefreshToken(refreshTokenDTO.Token);

            return ActionResultInstance(result);
        }

        [HttpPost("CreateTokenByRefreshToken")]
        public async Task<IActionResult>CreateTokenByRefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            var result = await _authenticationService.CreateTokenByRefreshToken(refreshTokenDTO.Token);
            return ActionResultInstance(result);
        }
    }
}
