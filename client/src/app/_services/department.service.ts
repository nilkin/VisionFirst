import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})

export class DepartmentService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.get(`${this.baseUrl}department/list`,model);
  }
}
