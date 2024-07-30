import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable()
export class ErrorCatchingInterceptor implements HttpInterceptor {

  constructor() {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<any> {
     return next.handle(request)
           .pipe(
                 catchError((error: HttpErrorResponse) => {
                    let errorMsg = '';
                    if (error.error instanceof ErrorEvent) {
                       errorMsg = `Error: ${error.error.message} | client Error`;
                       alert(errorMsg);
                    } else {
                       errorMsg = `Error Code: ${error.status},  Message: ${error.error.Message} | Server Error`;
                       alert(errorMsg);
                    }
                    return throwError(errorMsg);
                 })
           )
  }
}
