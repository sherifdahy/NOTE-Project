import { ProductUnitVm } from "../product-unit/product-unit-vm";

export interface ProductVm {
  name: string;
  productUnits: ProductUnitVm[];
}
