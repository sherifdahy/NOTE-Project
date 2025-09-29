import { Injectable } from '@angular/core';
import { ProductMapper } from '../mapper/product-mapper';
import { ReceiptMapper } from '../mapper/receipt-mapper';

@Injectable({
  providedIn: 'root'
})
export class MapperService {

constructor(
  public productMapper : ProductMapper,
  public receiptMapper : ReceiptMapper,
) { }

}
