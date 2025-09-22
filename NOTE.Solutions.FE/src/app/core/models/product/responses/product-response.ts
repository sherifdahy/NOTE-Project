import { ProductUnitResponse } from "../../product-unit/responses/product-unit-response";

export interface ProductResponse {
  id : number;
  name : string;
  productUnits : ProductUnitResponse[];
}
