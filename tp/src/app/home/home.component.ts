import { Component, OnInit } from '@angular/core';
import { DatasService } from '../datas.service';
import {Observable} from 'rxjs/Observable';
import { IntervalObservable } from 'rxjs/Observable/IntervalObservable';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

    datas: any;
    testwidth: any;
     // futaba圖片放置路徑
     futaba = {
      name:  'Futaba',
      picture: '/assets/icons/futaba.jpg'
     };
     private display: boolean; // whether to display info in the component
     // use *ngIf="display" in your html to take
     // advantage of this

     private alive: boolean; // used to unsubscribe from the IntervalObservable

  onResize(event) {
      this.testwidth = event.target.innerWidth;
   }

   getCSSClasses(flag: string) {
    let cssClasses;
    if (flag === '1024') {
         cssClasses = {
      'productTitle1024': true
   };
    } else {
         cssClasses = {
      'two': true,
      'four': false
   };
    }
    return cssClasses;
 }

   // tslint:disable-next-line:one-line
   constructor(private dataSvc: DatasService){
    this.display = false;
    this.alive = true;
   }

   ngOnInit() {
    //////////
    this.dataSvc.getAllDatas()
    .subscribe( data => {
       this.datas = data;
       this.display = true;
    });

    // get our data every subsequent 60 seconds
    IntervalObservable.create(60000)
    .subscribe(() => {
      this.dataSvc.getAllDatas()
        .subscribe(data => {
          this.datas = data;
        });
    });

  }
  // tslint:disable-next-line:use-life-cycle-interface
  ngOnDestroy() {
    this.alive = false; // switches your IntervalObservable off
  }
}
