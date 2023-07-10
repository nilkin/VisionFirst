import axios, { AxiosResponse } from 'axios';
import { Injectable } from '@angular/core';
import { environment } from '../_environments/_environment';
import { IDepartment } from '../_models/department';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable, from } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  baseUrl: string = environment.baseUrl;
  departments: IDepartment[] | any;
  private currentDepartSource = new BehaviorSubject<IDepartment[] | null>(null);
  currentDepart$ = this.currentDepartSource.asObservable();

  constructor() {}

 async getDepartments(): Promise<Observable<IDepartment[]>> {
    return from(
     axios.get<IDepartment[]>(`${this.baseUrl}department/list`)
    ).pipe(
      map((response: AxiosResponse<IDepartment[]>) => {
        const departments = response.data;
        if (departments) {
          this.currentDepartSource.next(departments);
        }
        return departments;
      })
    );
  }
}