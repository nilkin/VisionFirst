import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn = false;

  constructor(
    private accountServise: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}
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
    const response = await this.accountServise.login(this.model);
    if (response.status == 200) {
      this.router.navigateByUrl('/departments');
      this.toastr.success(`xos geldin ${response.data.email}`,'salam');
    } else {
      this.toastr.error( response,'Xeta',);
    }
  }

  logout() {
    this.accountServise.logout();
    this.router.navigateByUrl('/');
    this.loggedIn = false;
  }
}
