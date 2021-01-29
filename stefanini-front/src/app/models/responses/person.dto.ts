import { PhoneResponse } from "./phone.response";

export interface PersonDto {
  id: number;
  name: string;
  phones: PhoneResponse[];
}
