import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { PhoneRequest } from '../models/requests/phone.request';
import { PersonDto } from '../models/responses/person.dto';
import { PersonResponse } from '../models/responses/person.response';
import { PhoneTypeResponse } from '../models/responses/phone-type.response';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-phone-insert',
  templateUrl: './phone-insert.component.html',
  styleUrls: ['./phone-insert.component.css']
})
export class PhoneInsertComponent implements OnInit {
  public phoneRequest: PhoneRequest;
  public people: PersonDto[];
  public owner: PersonDto;
  public types: PhoneTypeResponse[];
  public selectedType: PhoneTypeResponse;
  public number: string;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getPerson();
    this.getTypes();
  }


  public getPerson() {
    this.people = new Array<PersonDto>();

    this.apiService.getPerson().subscribe((res: PersonResponse) => {
      this.people = res.personObjects;
    })
  }

  public getTypes() {
    this.types = new Array<PhoneTypeResponse>();

    this.apiService.getType().subscribe((res) => {
      this.types = res;
    })
  }

  private cleanFields() {
    this.owner = null;
    this.selectedType = null;
    this.number = "";
  }

  registerPhone(owner, number, type) {
    let ownerId = this.people.find(x => x.name == owner);
    let typeId = this.types.find(x => x.name == type);


    this.phoneRequest = new PhoneRequest({
      number: number,
      personId: ownerId.id,
      phoneTypeId: typeId.id
    });
    console.log(this.phoneRequest);

    this.apiService.registerPhone(this.phoneRequest).subscribe((res) => {
      alert("Phone " + number + " was sucessfully registered!");
      this.cleanFields();
    })
  }
}
