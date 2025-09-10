using NOTE.Solutions.Entities.Entities.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.DocumentDetail.Requests;

public class DocumentDetailRequest
{
    public decimal UnitPrice { get; set; }
    public decimal Quantity { get; set; }
    public int ProductUnitId { get; set; }

}
