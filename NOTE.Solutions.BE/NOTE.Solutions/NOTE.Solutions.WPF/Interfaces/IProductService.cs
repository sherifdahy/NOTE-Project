using NOTE.Solutions.WPF.Abstractions;
using NOTE.Solutions.WPF.DTOs.Product.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.WPF.Interfaces;

public interface IProductService
{
    Task<List<ProductResponse>> GetAllAsync(int branchId);
}
