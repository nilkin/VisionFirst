import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn = false;

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}
  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser() {
    this.accountService.currentAcc$.subscribe({
      next: (user) => (this.loggedIn = !!user),
      error: (err) => console.log(err),
    });
  }
  async login() {
    const response = await this.accountService.login(this.model);
    this.router.navigateByUrl('/departments');
    this.toastr.success(`xos geldin ${response.data.email}`, 'salam');
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
    this.loggedIn = false;
  }
}
