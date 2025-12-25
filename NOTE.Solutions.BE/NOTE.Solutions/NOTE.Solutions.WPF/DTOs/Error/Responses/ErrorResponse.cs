using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.WPF.DTOs.Error.Responses;

public class ErrorResponse
{
    public Dictionary<string, string[]> Errors { get; set; } = new();
}
