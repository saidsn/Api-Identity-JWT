using ServiceLayer.DTOs.Account;

namespace ServiceLayer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string?> LoginAsync(LoginDTO model);
        Task<ApiResponse> RegisterAsync(RegisterDTO model);
        Task CreateRoleAsync(RoleDTO model);
    }
}
