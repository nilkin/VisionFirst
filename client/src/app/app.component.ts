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
  baseUrl: string = environment.baseUrl;
  departments: IDepartment[] | any;
  constructor(
    private accountService: AccountService,
    private departmentService: DepartmentService
  ) {}

  ngOnInit(): void {
    this.getDepartments();
    this.setCurrentAccoun();
  }
  async getDepartments() {
    (await this.departmentService.getDepartments()).subscribe(
      (departments: IDepartment[]) => {
        this.departments = departments;
      },
      (error: any) => {
        console.error('Error retrieving departments:', error);
      }
    );
  }

  setCurrentAccoun() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: IAccount = JSON.parse(userString);
    this.accountService.setCurrentAccount(user);
  }
}
