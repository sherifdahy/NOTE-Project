import { inject, Injectable } from "@angular/core";
import { DocumentDetailRequest } from "../models/receipt/requests/document-detail-request";
import { ReceiptDocumentDetailVm } from "../view-models/receipt/receipt-document-detail-vm";

@Injectable({
  providedIn: 'root'
})
export class DocumentDetailMapper {
  toModel(documentdetail : ReceiptDocumentDetailVm) : DocumentDetailRequest {
    return {
      productUnitId: Number(documentdetail.productUnitId),
      quantity: Number(documentdetail.quantity),
      unitPrice: Number(documentdetail.unitPrice),
    }
  }
}
