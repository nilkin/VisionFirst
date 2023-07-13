import axios, { AxiosResponse } from 'axios';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IAccount } from '../_models/account';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../_environments/_environment';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl: string = environment.baseUrl;
  private currentAccSource = new BehaviorSubject<IAccount | null>(null);
  currentAcc$ = this.currentAccSource.asObservable();

  constructor() {}
  async register(model: any): Promise<any> {
    try {
      const response: AxiosResponse<IAccount> = await axios.post(
        `${this.baseUrl}account/register`, model);
      const user: IAccount = response.data;
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        this.currentAccSource.next(user);
        return response;
      }
    } catch (error) {
      return"Email addres is used";
    }
  }
  async login(model: any): Promise<any> {
    try {
      const response:AxiosResponse<IAccount> = await axios.post(
        `${this.baseUrl}account/login`, model);
      const user:IAccount = response.data;
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        this.currentAccSource.next(user);
        return response;
      }
    } catch (error) {
      return"Email or password error";
    }
  }
  

  setCurrentAccount(user: IAccount): void {
    this.currentAccSource.next(user);
  }

  logout(): void {
    localStorage.removeItem('user');
    this.currentAccSource.next(null);
  }
}
