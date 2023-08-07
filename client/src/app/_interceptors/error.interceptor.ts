import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router : Router,private toastr: ToastrService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error) {
          let errorMessage = 'An error occurred';
          switch (error.status) {
            case 400:
              if (error.error.errors) {
                const modelStateErrors = [];
                for (let key in error.error.errors) {
                  if (error.error.errors) {
                    modelStateErrors.push(error.error.errors[key]);
                  }
                  throw modelStateErrors.flat();
                }
              } else {
                this.toastr.error(error.error, error.status.toString());
              }
              break;
            case 401:
              this.toastr.error('Unauthorised', error.status.toString());
              break;
            case 404:
              this.router.navigateByUrl('/not-found');
              break;
            case 500:
              const navigateExtras:NavigationExtras = {state:{error:error.error}};
              this.router.navigateByUrl('/server-error',navigateExtras);
              this.toastr.error('Internal Server Error', error.status.toString());
              break;
            default:
              this.toastr.error('An error occurred');
              console.log(error);

          }

          // Use Toastr to display the error message as a toast
          this.toastr.error(errorMessage, 'Error');
          return throwError(errorMessage);
        }
        throw error;
      })
    );
  }
}
