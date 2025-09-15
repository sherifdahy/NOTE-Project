using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Authentication;

public class JWTProvider (IOptions<JwtOptions> options): IJWTProvider
{
    private readonly IOptions<JwtOptions> _options = options;

    public (string token, int expiresIn) GeneratedToken(ApplicationUser applicationUser)
    {
        Claim[] claims = [
            new Claim(JwtRegisteredClaimNames.Sub,applicationUser.Id.ToString()),
            new Claim("role",applicationUser.ApplicationRole.Role.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,applicationUser.Email),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        ];


        var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));

        var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var expiresIn = _options.Value.ExpiryMinutes;

        var expirationDate = DateTime.UtcNow.AddMinutes(expiresIn);

        var token = new JwtSecurityToken(
            issuer: _options.Value.Issuer,
            audience:_options.Value.Audience,
            claims:claims,
            expires:expirationDate,
            signingCredentials:signingCredentials
        );

        return (token: new JwtSecurityTokenHandler().WriteToken(token),expiresIn:expiresIn * 60);
    }
}
