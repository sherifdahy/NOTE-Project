import { PaymentMethodType } from "../../../../enums/payment-method-type";
import { DocumentBuyerRequest } from "./document-buyer-request";
import { DocumentDetailRequest } from "./document-detail-request";
import { DocumentHeaderRequest } from "./document-header-request";

export interface ReceiptRequest {
  header : DocumentHeaderRequest,
  buyer : DocumentBuyerRequest,
  activeCodeId : number,
  posId : number,
  paymentMethod : PaymentMethodType,
  documentDetails : DocumentDetailRequest[];
  documentTypeId : number,
}
