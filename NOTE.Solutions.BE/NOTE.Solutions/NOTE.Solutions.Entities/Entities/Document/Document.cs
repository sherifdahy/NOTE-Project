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
    public DateTime DateTime { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string UUID { get; set; } = string.Empty;

    public string BuyerName { get; set; } = string.Empty;
    public string BuyerSSN {  get; set; } = string.Empty;
    public BuyerType BuyerType { get; set; }

    public PaymentMethodType PaymentMethod { get; set; }

    public int BranchId { get; set; }
    public Branch Branch { get; set; }

    public int DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; }


    public ICollection<DocumentDetail> DocumentDetails { get; set; } = new HashSet<DocumentDetail>();

}



