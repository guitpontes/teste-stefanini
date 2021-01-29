import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { PhoneInsertComponent } from './phone-insert/phone-insert.component';
import { PhoneEditComponent } from './phone-edit/phone-edit.component';
import { PhoneDeleteComponent } from './phone-delete/phone-delete.component';
import { ApiService } from './services/api.service';
import { HttpClientModule } from '@angular/common/http';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  declarations: [
    AppComponent,
    PhoneInsertComponent,
    PhoneEditComponent,
    PhoneDeleteComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    // other imports ...
    ReactiveFormsModule,
    HttpClientModule,
    NgxMaskModule.forRoot()
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
