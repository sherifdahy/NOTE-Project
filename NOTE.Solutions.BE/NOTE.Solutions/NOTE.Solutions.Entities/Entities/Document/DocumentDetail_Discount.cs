using NOTE.Solutions.Entities.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Document;
public class DocumentDetail_Discount
{
    public decimal Amount { get; set; }
    public decimal Rate { get; set; }

    public int DocumentDetailId { get; set; }
    public DocumentDetail DocumentDetail { get; set; } = default!;

    public int DiscountId { get; set; }
    public DocumentDiscount Discount { get; set; } = default!;
    
}
