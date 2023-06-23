import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn = false;

  constructor(private accountServise: AccountService) {}
  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser() {
    this.accountServise.currentAcc$.subscribe({
      next: (user) => (this.loggedIn = !!user),
      error: (err) => console.log(err),
    });
  }
  login() {
    this.accountServise.login(this.model).subscribe({
      next: (resp) => {
        console.log(resp);
        this.loggedIn = true;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  logout() {
    this.accountServise.logout();
    this.loggedIn = false;
  }
}
