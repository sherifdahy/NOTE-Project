import { UnitResponse } from "../../unit/responses/unit-response";

export interface ProductUnitResponse {
  id : number;
  description: string;
  internalCode: string;
  globalCode: string;
  globalCodeType: number;
  unitPrice: number;
  unit: UnitResponse;
}
