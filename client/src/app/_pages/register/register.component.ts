import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { IAccount } from 'src/app/_models/account';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  validateForm!: UntypedFormGroup;
  @Output() cancelRegister = new EventEmitter();
  constructor(
    private fb: UntypedFormBuilder,
    private accountService: AccountService,
    private toastr: ToastrService
  ) {}

  register(): any {
    if (this.validateForm.valid) {
      var response = this.accountService.register(this.validateForm.value);
      console.log(response);
      response.then((response) => {
        this.toastr.success(response, 'Registration successful');
      });
      response.catch((error) => {
        this.toastr.error(error, 'Xeta');
      });
    } else {
      Object.values(this.validateForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      role: [1],
      employeeId: [3],
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });
  }

  cancel() {
    console.log('cancel');
    this.cancelRegister.emit(false);
  }
}
