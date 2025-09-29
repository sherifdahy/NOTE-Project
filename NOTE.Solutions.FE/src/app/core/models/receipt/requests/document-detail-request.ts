import { ProductUnitResponse } from "../../product-unit/responses/product-unit-response";

export interface DocumentDetailRequest {
  unitPrice: number;
  quantity: number;
  productUnitId: number;
}
