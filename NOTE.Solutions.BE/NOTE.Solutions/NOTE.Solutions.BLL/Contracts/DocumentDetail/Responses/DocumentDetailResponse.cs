using NOTE.Solutions.Entities.Entities.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.DocumentDetail.Responses;

public class DocumentDetailResponse
{
    public int Id { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Quantity { get; set; }
    public ProductUnitResponse? ProductUnit { get; set; }

}
