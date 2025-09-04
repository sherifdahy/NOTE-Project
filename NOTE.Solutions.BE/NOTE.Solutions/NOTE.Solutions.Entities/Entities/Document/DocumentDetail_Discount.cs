using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Document;
public class DocumentDetail_Discount
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public decimal Rate { get; set; }


    public ICollection<DocumentDetail> DocumentDetails { get; set; }
    public ICollection<Discount> Discounts { get; set; }
    
}
