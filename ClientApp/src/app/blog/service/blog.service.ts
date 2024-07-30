import { Injectable } from '@angular/core';
import { BlogModel } from '../model/blogpost.model';
import { ApiManagerService } from '../../service/api-service/api-manager.service';
import { HttpClient } from '@angular/common/http';
import { ApiController, UriConstants } from '../constants/api-methods-uri.constant';

@Injectable({
  providedIn: 'root'
})
export class BlogService extends ApiManagerService<BlogModel>  {

  constructor(protected httpClient: HttpClient) {
    super(httpClient);
  }

  getResourceUrl(uriContants: string): string {
    switch (uriContants) {
      case UriConstants.GET: {
        return `api/${ApiController.BLOG}`;
      }
      case UriConstants.GETITEMS: {
        return `api/${ApiController.BLOG}`;
      }
      case UriConstants.ADD: {
        return `api/${ApiController.BLOG}`;
      }
      case UriConstants.UPDATE: {
        return `api/${ApiController.BLOG}`;
      }
      case UriConstants.DELETE: {
        return `api/${ApiController.BLOG}`;
      }
      default: {
        return `api/${ApiController.BLOG}`;
      }
    }
  }
}
