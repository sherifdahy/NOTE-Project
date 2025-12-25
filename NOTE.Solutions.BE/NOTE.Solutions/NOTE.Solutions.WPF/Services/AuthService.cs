using Microsoft.Extensions.Options;
using NOTE.Solutions.WPF.Abstractions;
using NOTE.Solutions.WPF.Abstractions.Consts;
using NOTE.Solutions.WPF.DTOs.Auth.Requests;
using NOTE.Solutions.WPF.DTOs.Auth.Responses;
using NOTE.Solutions.WPF.DTOs.Error.Responses;
using NOTE.Solutions.WPF.Interfaces;
using NOTE.Solutions.WPF.Options;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NOTE.Solutions.WPF.Services;

public class AuthService(ICacheService cashService,IOptions<NoteOptions> options) : IAuthService
{
    private readonly ICacheService _cacheService = cashService;
    
    private readonly NoteOptions _options = options.Value;
    public async Task<Result<LoginResponse>> GetTokenAsync(LoginRequest request)
    {
        var client = new HttpClient()
        {
            BaseAddress = new Uri(_options.BaseUrl)
        };

        var response = await client.PostAsJsonAsync("api/auth/get-token", request);

        if (response.IsSuccessStatusCode)
        {
            await this._cacheService.SetAsync(KeyStorageConsts.TokenCacheKey, response);
                
            return Result.Success(await response.Content.ReadFromJsonAsync<LoginResponse>());
        }

        var errors = await response.Content.ReadFromJsonAsync<ErrorResponse>();

        var error = errors.Errors.First();

        return Result.Failure<LoginResponse>(new Error(error.Key, error.Value.First(), (int)response.StatusCode));
    }
}
