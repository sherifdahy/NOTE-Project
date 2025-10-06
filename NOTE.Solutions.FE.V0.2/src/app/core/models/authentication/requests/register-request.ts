import { BranchRequest } from "../../branch/requests/branch-request";

export interface RegisterRequest {
  name:string;
  rin : string;
  activeCodeId : number;
  branch : BranchRequest;
}
