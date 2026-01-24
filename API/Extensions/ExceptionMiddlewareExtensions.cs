using System.Net;
using Domain.ErrorModel;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Diagnostics;

namespace API.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    //Handle FK errors
                    var fkException =
                        contextFeature.Error.Message.Contains(
                            "The DELETE statement conflicted with the REFERENCE constraint \"FK");

                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        UnauthorizedException => StatusCodes.Status401Unauthorized,
                        ForbiddenException => StatusCodes.Status403Forbidden,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    logger.LogError($"Something went wrong: {contextFeature.Error}");

                    await context.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = fkException ? StatusCodes.Status400BadRequest : context.Response.StatusCode,
                        Message = fkException ? "لا يمكن الحذف لأنه/ـا مستخدم/ـة." : contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }
}