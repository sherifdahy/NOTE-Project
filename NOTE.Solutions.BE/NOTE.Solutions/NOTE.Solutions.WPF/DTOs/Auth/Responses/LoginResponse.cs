using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.WPF.DTOs.Auth.Responses;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public int ExpireIn { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiration { get; set; }
}
