using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Document;
public class DocumentDetail_Tax
{
    public int Id { get; set; }
    public decimal Rate { get; set; }
    public decimal Amount { get; set; }

    public ICollection<Tax> Taxes { get; set; } = new HashSet<Tax>();
    public ICollection<DocumentDetail> DocumentDetails { get; set; } = new HashSet<DocumentDetail>();

}
