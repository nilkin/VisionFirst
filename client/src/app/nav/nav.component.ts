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
  async login() {
    try {
      await this.accountServise.login(this.model);
      console.log('Login successful!');
    } catch (error) {
      console.error('Login error:', error);
    }
  }
  

  logout() {
    this.accountServise.logout();
    this.loggedIn = false;
  }
}
