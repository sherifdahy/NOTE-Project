import { ProductUnitReques } from "../../product-unit/requests/product-unit-request";

export interface ProductRequest {
  name : string;
  productUnits : ProductUnitReques[];
}
