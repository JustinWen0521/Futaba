import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { DatasService } from './datas.service';
import { HomeComponent } from './home/home.component';
import { MccodelistComponent } from './mccodelist/mccodelist.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { StrFormatPipe } from './str-format.pipe';
import { LoginGuard } from './login.guard';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MccodelistComponent,
    StrFormatPipe
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [DatasService, LoginGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
