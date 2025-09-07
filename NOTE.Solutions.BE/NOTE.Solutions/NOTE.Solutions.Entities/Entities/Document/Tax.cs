using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Document;
public class Tax : AuditableEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;

    public int DocumentDetail_TaxId { get; set; }
    public DocumentDetail_Tax DocumentDetail_Tax { get; set; }
}
