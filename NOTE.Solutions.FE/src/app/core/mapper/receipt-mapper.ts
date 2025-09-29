import { Injectable } from "@angular/core";
import { ReceiptRequest } from "../models/receipt/requests/receipt-request";
import { ReceiptVm } from "../view-models/receipt/receipt-vm";
import { DocumentDetailMapper } from "./document-detail-mapper";


@Injectable({
  providedIn: 'root'
})
export class ReceiptMapper {
  constructor(private documentDetailMapper : DocumentDetailMapper)
  {

  }
  toModel(receiptVm : ReceiptVm) : ReceiptRequest {
    return {
      header: {
        dateTime: new Date(receiptVm.header.dateTime).toISOString(),
        documentNumber: receiptVm.header.documentNumber,
      },
      buyer: {
        name: receiptVm.buyer.name,
        ssn: receiptVm.buyer.ssn,
        type: Number(receiptVm.buyer.type),
      },
      posId : Number(receiptVm.posId),
      paymentMethod: Number(receiptVm.paymentMethod),
      activeCodeId: Number(receiptVm.activeCodeId),
      documentDetails: receiptVm.documentDetails.map(dd=> this.documentDetailMapper.toModel(dd)),
      documentTypeId : Number(receiptVm.documentTypeId),
    }
  }
}
