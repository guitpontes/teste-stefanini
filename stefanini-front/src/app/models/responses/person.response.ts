import { BaseResponse } from "./base.response";
import { PersonDto } from "./person.dto";

export interface PersonResponse extends BaseResponse {
  personObjects: PersonDto[];
}
