import { Component, OnInit } from '@angular/core';
import { PhoneEditRequest } from '../models/requests/phone-edit.request';
import { PhoneRequest } from '../models/requests/phone.request';
import { PhoneTypeResponse } from '../models/responses/phone-type.response';
import { PhoneResponse } from '../models/responses/phone.response';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-phone-edit',
  templateUrl: './phone-edit.component.html',
  styleUrls: ['./phone-edit.component.css']
})
export class PhoneEditComponent implements OnInit {
  public phones: PhoneResponse[] = new Array<PhoneResponse>();
  public phoneNumber: string;
  public validPhone: PhoneResponse;
  public types: PhoneTypeResponse[];
  public selectedType: PhoneTypeResponse;
  public newNumber: string;
  public request: PhoneEditRequest;

  constructor(private apiService: ApiService) {
  }
  ngOnInit(): void {
    this.getPhones();
    this.getTypes();
  }

  private getPhones() {
    this.phones = new Array<PhoneResponse>();
    this.apiService.getPhones().subscribe((res) => {
      if (res)
        this.phones = res;
    });
  }

  update(args, type) {
    let phone = this.phones.find(x => x.number == args);
    let typeId = this.types.find(x => x.name == type);

    this.request = new PhoneRequest({
      number: this.formatPhoneNumber(this.newNumber),
      personId: phone.id,
      phoneTypeId: typeId.id
    })

    this.apiService.editPhone(phone, this.request).subscribe((res) => {
      alert("Phone " + args + " was successfully edited");
      this.cleanFields();
    })
  }

  public getTypes() {
    this.types = new Array<PhoneTypeResponse>();
    this.apiService.getType().subscribe((res) => {
      this.types = res;
    })
  }

  private cleanFields() {
    this.getPhones();
    this.selectedType = null;
    this.newNumber = "";
  }

  formatPhoneNumber(phoneNumberString) {
    var cleaned = ('' + phoneNumberString).replace(/\D/g, '')
    var match = cleaned.match(/^(\d{2})(\d{5})(\d{4})$/)
    if (match) {
      return '(' + match[1] + ')' + match[2] + '-' + match[3]
    }
    return null
  }
}
