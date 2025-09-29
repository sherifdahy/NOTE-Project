import { ActiveCodeResponse } from "../../active-code/response/active-code-response";
import { DocumentTypeResponse } from "../../document-type/responses/document-type-response";
import { DocumentBuyerResponse } from "./document-buyer-response";
import { DocumentDetailResponse } from "./document-detail-response";
import { DocumentHeaderResponse } from "./document-header-response";

export interface ReceiptResponse {
  id: number;
  documentType: DocumentTypeResponse;
  documentDetails: DocumentDetailResponse[];
  header: DocumentHeaderResponse;
  buyer: DocumentBuyerResponse;
  pos : any;
  activeCode : ActiveCodeResponse,
  paymentMethod: number;
}
