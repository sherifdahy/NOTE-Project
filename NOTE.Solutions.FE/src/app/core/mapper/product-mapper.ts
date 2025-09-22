import { Injectable } from "@angular/core";
import { ProductRequest } from "../models/product/requests/product-request";
import { ProductVm } from "../view-models/product/product-vm";
import { ProductUnitMapper } from "./product-unit-mapper";

@Injectable({
  providedIn: 'root',
})
export class ProductMapper {
  constructor(private productUnitMapper : ProductUnitMapper)
  {

  }
  toModel(productVm: ProductVm): ProductRequest {
    return {
      name: productVm.name,
      productUnits: productVm.productUnits.map((productUnitVM)=> this.productUnitMapper.toModel(productUnitVM) ),
    };
  }
}
