using NOTE.Solutions.Entities.Entities.Company;
using NOTE.Solutions.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Document;
public class Document : AuditableEntity
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public int DocumentTypeId { get; set; }
    public int HeaderId { get; set; }
    public int BuyerId { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }


    public DocumentHeader Header { get; set; } = default!;
    public Branch Branch { get; set; } = default!;
    public DocumentBuyer Buyer { get; set; } = default!;
    public DocumentType DocumentType { get; set; } = default!;
    public ICollection<DocumentDetail> DocumentDetails { get; set; } = new HashSet<DocumentDetail>();
}



