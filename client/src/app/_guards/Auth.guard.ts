import { inject } from '@angular/core';
import { CanActivateFn , Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';
import { Observable, map } from 'rxjs';

export const authGuard: CanActivateFn = (): boolean | Observable<boolean> | Promise<boolean> => {

  const _toastr: ToastrService = inject(ToastrService);
  const _account = inject(AccountService);
  const _router = inject(Router);
  return _account.currentAcc$.pipe(
    map(user => {
      if (user) {
        return true;
      } else {
        _toastr.error(
          'Please log in to access this page.',
          'Authentication Required'
        );
        _router.navigate(['']);
        return false;
      }
    })
  );
};

