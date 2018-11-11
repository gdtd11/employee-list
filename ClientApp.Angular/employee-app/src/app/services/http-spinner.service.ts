import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SpinnerLoaderService } from './spinner-loader.service';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/from';
import 'rxjs/add/operator/finally';

@Injectable()
export class HttpSpinnerService {
  baseUrl = 'http://localhost:5000/api';

  constructor(private http: HttpClient, private spinnerService: SpinnerLoaderService) { }

  doQuery<T>(method: Observable<T>): Observable<T> {
    this.spinnerService.show();
    //console.log('START');

    return Observable.from(method)
     .finally(() => {
      //console.log('STOP');
       this.spinnerService.hide();
     });

  }

  get<T>(url: string): Observable<T> {
    return this.doQuery<T>(this.http.get<T>(this.baseUrl + url));
  }

  post(url: string, obj: Object) {
    return this.doQuery(this.http.post(this.baseUrl + url, obj));
  }

   delete(url: string){
    return this.doQuery(this.http.delete(this.baseUrl + url));
   }

  put(url: string, obj: Object) {
    return this.doQuery(this.http.put(this.baseUrl + url, obj));
  }
}
