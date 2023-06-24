import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../_environments/_environment';
import { IDepartment } from '../_models/department';
import { map } from 'rxjs/internal/operators/map';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  baseUrl: string = environment.baseUrl;
  departments:IDepartment[]| any;
  private currentDepartSource = new BehaviorSubject<IDepartment[] | null>(null);
  currentDepart$ = this.currentDepartSource.asObservable();
  constructor(private http: HttpClient) {}

  getDepartments(): Observable<IDepartment[]> {
    return this.http.get<IDepartment[]>(`${this.baseUrl}department/list`).pipe(
      map((response: IDepartment[]) => {
        const departments = response;
        if (departments) {
          this.currentDepartSource.next(departments);
        }
        return departments;
      })
    );
  }
}
