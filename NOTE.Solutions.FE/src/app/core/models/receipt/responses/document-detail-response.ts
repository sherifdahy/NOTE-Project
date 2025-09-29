import { ProductUnitResponse } from "../../product-unit/responses/product-unit-response";

export interface DocumentDetailResponse {
  id : number;
  unitPrice : number;
  quantity : number;
  productUnit : ProductUnitResponse
}

