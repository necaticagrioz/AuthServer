using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SharedLibrary.DTO_s;
using SharedLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharedLibrary.Extensions
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType= "application/json";

                    var errorFuture = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFuture != null)
                    {
                        var ex = errorFuture.Error;
                        ErrorDTO errorDTO = null;

                        if (ex is CustomException)
                        {
                            errorDTO = new ErrorDTO(ex.Message, true);
                        }
                        else
                        {
                            errorDTO = new ErrorDTO(ex.Message, false);
                        }

                        var response = Response<NoDataDTO>.Fail(errorDTO, 500);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
