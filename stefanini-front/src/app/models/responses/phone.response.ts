import { BaseResponse } from "./base.response";

export interface PhoneResponse extends BaseResponse {
  id: number;
  number: string;
  phoneType: string;
  phoneTypeID: number;
  owner: string;
}
