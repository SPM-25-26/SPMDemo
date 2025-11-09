using Microsoft.AspNetCore.Mvc;
using SPMDemo.Models.Dtos;
using SPMDemo.Models.Services.Infrastructure;

namespace SPMDemo.Endpoints
{
    internal static class AuthEndpoints
    {
        public static IResult GenerateToken(
            [FromServices] IAuthService authService,
            [FromBody] LoginCredentials credentials)
        {
            string? token = authService.GenerateToken(credentials);

            if (string.IsNullOrEmpty(token))
            {
                return Results.Unauthorized();
            }

            return Results.Ok(new { token });

        }
    }
}
