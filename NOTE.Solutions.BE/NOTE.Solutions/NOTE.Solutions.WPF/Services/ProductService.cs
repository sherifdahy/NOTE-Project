using NOTE.Solutions.WPF.DTOs.Product.Responses;
using NOTE.Solutions.WPF.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;

namespace NOTE.Solutions.WPF.Services;

public class ProductService : IProductService
{
    public ProductService()
    {
    }

    public Task<List<ProductResponse>> GetAllAsync(int branchId)
    {
        throw new System.NotImplementedException();
    }
}
