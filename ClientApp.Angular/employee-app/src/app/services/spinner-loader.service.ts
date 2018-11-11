import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable()
export class SpinnerLoaderService {
  private subject = new Subject<any>();

  constructor() { }

  show() {
    this.subject.next({ show: true});
  }

  hide() {
    this.subject.next({ show: false});
  }

  getMessage(): Observable<any> {
    return this.subject.asObservable();
}
}
