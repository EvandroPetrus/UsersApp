using Microsoft.Identity.Client;
using System.Net;
using UsuariosApp.API.Models;
using UsuariosApp.Domain.Exceptions.Usuarios;

namespace UsuariosApp.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate? _next;

        public ExceptionMiddleware(RequestDelegate? next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (AccessDeniedException e)
            {
                await HandleExceptionAsync(context, e);
            }

            catch (UserNotFoundException e)
            {
                await HandleExceptionAsync(context, e);
            }

            catch (EmailAlreadyRegistered e)
            {
                await HandleExceptionAsync(context, e);
            }

            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }
        
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {           
            switch (exception)
            {
                case EmailAlreadyRegistered:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;                    
                    break;

                case UserNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case AccessDeniedException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case Exception:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }            
            
            context.Response.ContentType = "application/json";
            
            var model = new ErrorViewModel();
            model.StatusCode = context.Response.StatusCode;
            model.Message = exception.Message;

            await context.Response.WriteAsync(model.ToString());
        }
    }
}
