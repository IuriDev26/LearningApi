﻿using Microsoft.AspNetCore.Diagnostics;

namespace SecondApi.Middlewares {
    public static class ConfigureExceptionMiddlewareExtensions {

        public static void ConfigureExceptionHandler(this IApplicationBuilder app) {
            app.UseExceptionHandler(appError => {
                appError.Run(async context => {

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if ( contextFeature != null ) {
                        await context.Response.WriteAsync(new ErrorDetails {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace
                        }.ToString());
                    }

                });


            });
        
        
        }


    }
}
