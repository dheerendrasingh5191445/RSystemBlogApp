import { HttpClient,HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { UriConstants } from '../../blog/constants/api-methods-uri.constant';
import { environment } from '../../../environments/environment';

export abstract class ApiManagerService<T> {
  protected readonly APIUrl: any;

  constructor(protected httpClient: HttpClient) {
    this.APIUrl = environment.baseApiUrl;
  }

  abstract getResourceUrl(uriContants: string): string;

  get(id: string | number): Observable<T> {
    return this.httpClient.get<T>(
      this.APIUrl + this.getResourceUrl(UriConstants.GET) + `/${id}`
    );
  }

  getAll(): Observable<T[]> {
    return this.httpClient.get<T[]>(
      this.APIUrl + this.getResourceUrl(UriConstants.GETITEMS)
    );
  }

  add(resource: T): Observable<any> {
    return this.httpClient.post(
      this.APIUrl + this.getResourceUrl(UriConstants.ADD),
      resource
    );
  }

  delete(id: string | number): Observable<any> {
    return this.httpClient.delete(
      this.APIUrl + this.getResourceUrl(UriConstants.DELETE) + `/${id}`
    );
  }

  update(resource: T) {
    return this.httpClient.put(
      this.APIUrl + this.getResourceUrl(UriConstants.UPDATE),
      resource
    );
  }

}
