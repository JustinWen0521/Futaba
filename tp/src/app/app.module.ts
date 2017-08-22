import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http';

import { AppComponent } from './app.component';
import { Page1Component } from './page1/page1.component';
import { DatasService } from './datas.service';

@NgModule({
  declarations: [
    AppComponent,
    Page1Component
  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [DatasService],
  bootstrap: [AppComponent,Page1Component]
})
export class AppModule { }
