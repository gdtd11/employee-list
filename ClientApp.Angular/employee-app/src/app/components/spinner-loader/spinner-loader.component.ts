import { Component, OnInit, Output } from '@angular/core';
import { EventEmitter } from 'events';
import { SpinnerLoaderService } from '../../services/spinner-loader.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-spinner-loader',
  templateUrl: './spinner-loader.component.html',
  styleUrls: ['./spinner-loader.component.css']
})
export class SpinnerLoaderComponent implements OnInit {
  show: boolean;
  subscription: Subscription;

  constructor(private spinnerService: SpinnerLoaderService) {
    console.log('in constructor');
    this.subscription = this.spinnerService.getMessage()
        .subscribe(message => { this.show = message.show; });
  }

  ngOnInit() {
  }

  OnDestroy() {
    this.subscription.unsubscribe();
}
}
