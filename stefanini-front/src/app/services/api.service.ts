import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PhoneEditRequest } from "../models/requests/phone-edit.request";
import { PhoneRequest } from "../models/requests/phone.request";
import { PersonResponse } from "../models/responses/person.response";
import { PhoneTypeResponse } from "../models/responses/phone-type.response";
import { PhoneResponse } from "../models/responses/phone.response";

@Injectable({
  providedIn: "root"
})
export class ApiService {

  private get urlBase() {
    return "http://localhost:5000/api/";
  }

  constructor(private http: HttpClient) {

  }

  getPhones(): Observable<Array<PhoneResponse>> {
    return this.http.get<Array<PhoneResponse>>(this.urlBase + 'phones');
  }

  deletePhone(phone: PhoneResponse): Observable<Boolean> {
    return this.http.delete<Boolean>(this.urlBase + 'phones', { params: { PersonId: phone.id.toString(), Number: phone.number, PhoneTypeId: phone.phoneTypeID.toString() } });
  }

  getPerson(): Observable<PersonResponse> {
    return this.http.get<PersonResponse>(this.urlBase + 'person');
  }

  getType(): Observable<Array<PhoneTypeResponse>> {
    return this.http.get<Array<PhoneTypeResponse>>(this.urlBase + 'phones/types');
  }

  registerPhone(request: PhoneRequest): Observable<PhoneResponse> {
    return this.http.post<PhoneResponse>(this.urlBase + 'phones', request);
  }

  editPhone(phone: PhoneResponse, request: PhoneEditRequest): Observable<PhoneResponse> {
    return this.http.put<PhoneResponse>(this.urlBase + 'phones', request, { params: { PersonId: phone.id.toString(), Number: phone.number, PhoneTypeId: phone.phoneTypeID.toString() } });
  }

}
