export class PhoneRequest {
  personId: number;
  phoneTypeId: number;
  number: string;

  constructor(params: Partial<PhoneRequest>) {
    this.personId = +params.personId;
    this.phoneTypeId = +params.phoneTypeId;
    this.number = params.number;
  }
}
