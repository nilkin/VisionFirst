import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { IEmployee } from '../_models/employee';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}
  getEmployee(id: number) {
    return this.http.get<IEmployee>(
      this.baseUrl + 'employee/' + id,
      this.getHttpOptions()
    );
  }
  getEmployees() {
    return this.http.get<IEmployee[]>(
      this.baseUrl + 'employee/list',
      this.getHttpOptions()
    );
  }
  getHttpOptions() {
    const userStr = localStorage.getItem('user');
    if (!userStr) return;
    const user = JSON.parse(userStr);
    return {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + user.token,
      }),
    };
  }
}
