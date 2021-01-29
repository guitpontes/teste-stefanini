import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { PhoneResponse } from '../models/responses/phone.response';
import { ApiService } from '../services/api.service';

interface Phone {
  number?: string;
}
@Component({
  selector: 'app-phone-delete',
  templateUrl: './phone-delete.component.html',
  styleUrls: ['./phone-delete.component.css']
})

export class PhoneDeleteComponent implements OnInit {
  public phones: PhoneResponse[] = new Array<PhoneResponse>();
  public phoneNumber: string;
  public validPhone: PhoneResponse;

  constructor(private apiService: ApiService) {
  }
  ngOnInit(): void {
    this.getPhones();
  }

  private getPhones() {
    this.phones = new Array<PhoneResponse>();
    this.apiService.getPhones().subscribe((res) => {
      if (res)
        this.phones = res;
    });
  }

  delete(args) {
    let x = this.phones.find(x => x.number == args);

    this.apiService.deletePhone(x).subscribe((res) => {
      alert("Phone " + args + " was successfully deleted");
      this.getPhones();
    })
  }
}
