import { Injectable } from '@angular/core';
import { ProductMapper } from '../mapper/product-mapper';

@Injectable({
  providedIn: 'root'
})
export class MapperService {

constructor(public productMapper : ProductMapper,

) { }

}
