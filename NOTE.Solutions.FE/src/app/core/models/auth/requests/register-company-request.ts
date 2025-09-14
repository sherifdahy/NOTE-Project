import { BranchRequest } from "../../branch/requests/branch-request";

export interface RegisterCompanyRequest {
  name:string;
  rin : string;
  activeCodeId : number;
  branch : BranchRequest;
}
