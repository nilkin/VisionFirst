import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
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
  constructor(private fb: UntypedFormBuilder,private accountService :AccountService) {}
  
  register(): any {
    if (this.validateForm.valid) {
      this.accountService.register(this.validateForm.value)
        .then(() => {
          console.log('Registration successful');
        })
        .catch((error) => {
          console.error('Registration error:', error);
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
