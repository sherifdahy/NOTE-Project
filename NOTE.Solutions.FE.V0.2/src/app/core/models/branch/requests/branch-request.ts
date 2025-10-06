import { UserRequest } from "../../user/requests/user-request";

export interface BranchRequest {
  cityId : number;
  code : string;
  applicationUser : UserRequest;
}
