import { Injectable } from '@angular/core';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

confirm(title: string, message: string, okCallback: () => any, onError: () => any){
  alertify.confirm(message, function(e){
    if(e){
      okCallback();
    }
    else{
      onError();
    }
  })
  .setHeader('<h5> Remove </h5> ')
  .set('movable', false); 
}

  success(message: string){
    alertify.success(message);
  }

  error(message: string){
    alertify.error(message);
  }
}
