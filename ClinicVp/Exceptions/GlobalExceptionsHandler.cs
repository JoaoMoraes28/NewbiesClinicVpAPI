using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Exceptions
{
    public class GlobalExceptionsHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            int statusCode;
            string message;

            switch (exception)
            {
                case Microsoft.EntityFrameworkCore.DbUpdateException:
                    {

                        statusCode = StatusCodes.Status500InternalServerError;
                        message = "Chave viola restrições no banco de dados.";
                        break;
                    }

                case KeyNotFoundException:
                    {
                        statusCode = StatusCodes.Status404NotFound;
                        message = "O registro com o ID informado não foi encontrado.";
                        break;
                    }


                case UnauthorizedAccessException:
                    {
                        statusCode = StatusCodes.Status401Unauthorized;
                        message = "Você não tem permissão para acessar este módulo.";
                        break;
                    }

                case ArgumentException:
                    {
                        statusCode = StatusCodes.Status400BadRequest;
                        message = "Atributos enviados são inválidos.";
                        break;
                    }

                case InvalidOperationException:
                    {
                        statusCode = StatusCodes.Status400BadRequest;
                        message = "Atributos enviados são inválidos.";
                        break;
                    }

                default:
                    {
                        statusCode = StatusCodes.Status500InternalServerError;
                        message = "Erro interno.";
                        break;
                    }
            }

            httpContext.Response.StatusCode = statusCode;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = "Erro na requisição",
                Detail = message
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
