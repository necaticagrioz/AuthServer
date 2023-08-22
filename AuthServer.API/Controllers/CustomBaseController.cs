﻿using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTO_s;

namespace AuthServer.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {
       public IActionResult ActionResultInstance<T>(Response<T>response)where T : class 
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
