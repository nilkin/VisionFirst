import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../_environments/_environment';
import { IDepartment } from '../_models/department';
import { map } from 'rxjs/internal/operators/map';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  baseUrl: string = environment.baseUrl;
  departments:IDepartment[]| any;
  constructor(private http: HttpClient) {}

  // getDepartments() {
  //   return this.http.get<IDepartment>(`${this.baseUrl}department/list`).subscribe({
  //     next: (response) => (this.department = response),
  //     error: (error) => console.log(error),
  //   });
  // }

  getDepartments() {
    return this.http.get<IDepartment[]>(`${this.baseUrl}department/list`).pipe(
      map((response: IDepartment[]) => {
        const departments = response;
        if (departments) {
          this.departments = departments
        }
      })
    );
  }
}
