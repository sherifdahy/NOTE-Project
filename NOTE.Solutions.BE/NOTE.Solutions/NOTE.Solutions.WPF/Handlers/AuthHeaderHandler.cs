using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Caching.Memory;
using NOTE.Solutions.WPF.Abstractions.Consts;
using NOTE.Solutions.WPF.DTOs.Auth.Responses;
using NOTE.Solutions.WPF.Interfaces;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NOTE.Solutions.WPF.Handlers;

public class AuthHeaderHandler(ICacheService cacheService) : DelegatingHandler
{
    private readonly ICacheService _cacheService = cacheService;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authResponse = await _cacheService.GetAsync<LoginResponse>(KeyStorageConsts.TokenCacheKey);

        if (authResponse == null)
        {
            // handle refreshToken
            throw new NullReferenceException();
        }

        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResponse.Token);
        return await base.SendAsync(request, cancellationToken);
    }
}
