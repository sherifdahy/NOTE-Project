using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Entities.Document;

public class DocumentHeader : AuditableEntity
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string UUID { get; set; } = string.Empty;

    public Document Document { get; set; } = default!;
}
