using NOTE.Solutions.Entities.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Document;
public class DocumentDetail
{
    public int Id { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Quantity { get; set; }
    public int ProductUnitId { get; set; }
    public int DocumentId { get; set; }


    public Document Document { get; set; } = default!;
    public ProductUnit ProductUnit { get; set; } = default!;
    public ICollection<DocumentDetail_Discount> DocumentDetail_Discounts { get; set; } = new HashSet<DocumentDetail_Discount>();
    public ICollection<DocumentDetail_Tax> DocumentDetail_Taxes { get; set; } = new HashSet<DocumentDetail_Tax>();
}

