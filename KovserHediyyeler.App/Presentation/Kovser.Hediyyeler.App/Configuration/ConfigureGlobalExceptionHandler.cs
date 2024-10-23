using KovserHedieyyeler.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;
using System.Text.Json.Serialization;

namespace Kovser.Hediyyeler.App.Configuration
{
    public static class ConfigureGlobalExceptionHandler
    {
        public static void ConfigureExceptionHandler(this  IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var statuscode = (int)HttpStatusCode.InternalServerError;
                    var message = "Internal error";
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        if (contextFeature.Error is BaseException res)
                        {
                            statuscode = (int)res.StatusCode;
                            message = res.Message;
                        }
                        context.Response.StatusCode = statuscode;

                        var result = JsonConvert.SerializeObject(new { statusCode = statuscode, message = message });
                        await context.Response.WriteAsync(result);
                    }
                });
            }); 
        }
    }
}
