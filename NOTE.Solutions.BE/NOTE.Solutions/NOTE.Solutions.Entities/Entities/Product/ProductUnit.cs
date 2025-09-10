using NOTE.Solutions.Entities.Entities.Document;
using NOTE.Solutions.Entities.Entities.Unit;
using NOTE.Solutions.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Product;
public class ProductUnit : AuditableEntity
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string InternalCode { get; set; } = string.Empty;
    public string GlobalCode { get; set; } = string.Empty;
    public GlobalCodeType GlobalCodeType { get; set; }
    public decimal UnitPrice { get; set; }


    public int UnitId { get; set; }
    public Unit.Unit? Unit { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public ICollection<DocumentDetail> DocumentDetails { get; set; } = new HashSet<DocumentDetail>();
}


