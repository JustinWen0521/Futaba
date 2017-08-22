import { Component, OnInit } from '@angular/core';
import { DatasService } from '../datas.service';
@Component({
  selector: 'app-page1',
  templateUrl: './page1.component.html',
  styleUrls: ['./page1.component.css']
})
export class Page1Component implements OnInit {

   day:string ='日';
   night:string ='夜';
   todos: any;

   constructor(private dataSvc: DatasService){
   }

   ngOnInit() {
    this.dataSvc.getAllDatas()
    .subscribe(data =>{


    });
  }

}
