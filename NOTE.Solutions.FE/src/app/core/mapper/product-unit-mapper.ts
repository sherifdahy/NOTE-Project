import { Injectable } from "@angular/core";
import { ProductUnitVm } from "../view-models/product-unit/product-unit-vm";
import { ProductUnitReques } from "../models/product-unit/requests/product-unit-request";

@Injectable({
  providedIn: 'root',
})
export class ProductUnitMapper {
  toModel(productUnitVM: ProductUnitVm): ProductUnitReques {
    return {
      description: productUnitVM.description,
      internalCode: productUnitVM.internalCode,
      unitPrice: Number(productUnitVM.unitPrice),
      globalCode: productUnitVM.globalCode,
      globalCodeType: Number(productUnitVM.globalCodeType),
      unitId:Number(productUnitVM.unitId),
    }
  }
}
