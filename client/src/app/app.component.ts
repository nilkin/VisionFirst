import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { IAccount } from './_models/account';
import { environment } from './_environments/_environment';
import { IDepartment } from './_models/department';
import { DepartmentService } from './_services/department.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  department: IDepartment[] | any;
  baseUrl: string = environment.baseUrl;
  constructor(
    private http: HttpClient,
    private accountService: AccountService,
    private departmentService: DepartmentService
  ) {}

  ngOnInit(): void {
    this.getDepartments();
    this.setCurrentAccoun();
  }

  getDepartments() {
    this.http.get<IDepartment>(`${this.baseUrl}department/list`).subscribe({
      next: (response) => (this.department = response),
      error: (error) => console.log(error),
    });
  }
  // getDepartments()  {
  //   this.department = this.departmentService.getDepartments();
  // }

  setCurrentAccoun() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: IAccount = JSON.parse(userString);
    this.accountService.setcurrentAccount(user);
  }
}
