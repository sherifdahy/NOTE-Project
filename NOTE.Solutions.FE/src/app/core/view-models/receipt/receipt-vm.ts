import { PaymentMethodType } from "../../../enums/payment-method-type";
import { ReceiptBuyerVm } from "./receipt-buyer-vm";
import {ReceiptDocumentDetailVm } from "./receipt-document-detail-vm";
import { ReceiptHeaderVm } from "./receipt-header-vm";

export interface ReceiptVm {
  activeCodeId : number,
  header : ReceiptHeaderVm,
  buyer : ReceiptBuyerVm,
  documentDetails : ReceiptDocumentDetailVm[],
  posId : number,
  paymentMethod : PaymentMethodType,
  documentTypeId : number,
}
