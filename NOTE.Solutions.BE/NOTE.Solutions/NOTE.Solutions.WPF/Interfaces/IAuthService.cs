using NOTE.Solutions.WPF.Abstractions;
using NOTE.Solutions.WPF.DTOs.Auth.Requests;
using NOTE.Solutions.WPF.DTOs.Auth.Responses;
using System.Threading.Tasks;

namespace NOTE.Solutions.WPF.Interfaces;

public interface IAuthService
{
    Task<Result<LoginResponse>> GetTokenAsync(LoginRequest request);
}
