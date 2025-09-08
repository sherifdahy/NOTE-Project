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

    public int DocumentId { get; set; }
    public Document Document { get; set; }

    public int DocumentDetail_DiscountId { get; set; }
    public DocumentDetail_Discount DocumentDetail_Discount { get; set; }

    public int ProductUnitId { get; set; }
    public ProductUnit ProductUnit { get; set; }

    public ICollection<DocumentDetail_Tax> DocumentDetail_Taxes { get; set; } = new HashSet<DocumentDetail_Tax>();
}

