using NOTE.Solutions.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Product;
public class ProductUnit
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string InternalCode { get; set; } = string.Empty;
    public string GlobalCode { get; set; } = string.Empty;
    public GlobalCodeType GlobalCodeType { get; set; }
    public decimal UnitPrice { get; set; }


    public int ProductId { get; set; }
    public Product Product { get; set; }
}


