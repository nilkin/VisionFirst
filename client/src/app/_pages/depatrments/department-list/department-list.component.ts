import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { IDepartment } from 'src/app/_models/department';
import { DepartmentService } from 'src/app/_services/department.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.scss'],
})
export class DepartmentListComponent implements OnInit {
  departments: IDepartment[] | any;
  constructor(private departmentService: DepartmentService) {}
  ngOnInit(): void {
    this.getDepartments();
  }

  async getDepartments() {
    try {
      this.departments = await lastValueFrom(
        await this.departmentService.getDepartments()
      );
    } catch (error) {
      console.error('Error retrieving departments:', error);
    }
  }
}
