import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { IAccount } from './_models/account';
import { environment } from './_environments/_environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  baseUrl: string = environment.baseUrl;
  constructor(
    private accountService: AccountService,
  ) {}

  ngOnInit(): void {

    this.setCurrentAccoun();
  }
  setCurrentAccoun() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: IAccount = JSON.parse(userString);
    this.accountService.setCurrentAccount(user);
  }
}
