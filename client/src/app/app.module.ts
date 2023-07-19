import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { HomeComponent } from './_pages/home/home.component';
import { RegisterComponent } from './_pages/register/register.component';
import { CommonModule } from '@angular/common';
import { DepartmentListComponent } from './_pages/depatrments/department-list/department-list.component';
import { DepartmentDetailComponent } from './_pages/depatrments/department-detail/department-detail.component';
import { SharedModule } from './_modules/shared.module';

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    DepartmentListComponent,
    DepartmentDetailComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    SharedModule,
  ],

  bootstrap: [AppComponent],
})
export class AppModule {}
