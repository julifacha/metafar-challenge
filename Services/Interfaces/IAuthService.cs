using Services.Commands;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(LoginCommand loginDto);
    }
}
