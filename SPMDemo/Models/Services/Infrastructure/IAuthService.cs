using SPMDemo.Models.Dtos;

namespace SPMDemo.Models.Services.Infrastructure
{
    public interface IAuthService
    {
        string? GenerateToken(LoginCredentials credentials);
    }
}
