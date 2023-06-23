import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/internal/operators/map';
import { IAccount } from '../_models/account';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../_environments/_environment';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl:string = environment.baseUrl;
  private currentAccSource = new BehaviorSubject<IAccount | null>(null);
  currentAcc$ = this.currentAccSource.asObservable();
  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post<IAccount>(`${this.baseUrl}account/login`, model).pipe(
      map((response: IAccount) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentAccSource.next(user);
        }
      })
    );
  }

  setcurrentAccount(user: IAccount) {
    this.currentAccSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentAccSource.next(null);
  }
}
