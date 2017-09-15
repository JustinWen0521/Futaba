import { Component, OnInit } from '@angular/core';
import { DatasService } from '../datas.service';
@Component({
  selector: 'app-page1',
  templateUrl: './page1.component.html',
  styleUrls: ['./page1.component.css']
})
export class Page1Component implements OnInit {

    datas: any;

     futaba = {
      name: 'Futaba',
      picture: '/assets/icons/futaba.jpg'
     };
   constructor(private dataSvc: DatasService) {
   }

   ngOnInit() {
    this.dataSvc.getAllDatas()
    .subscribe( data => {
       this.datas = data;
    });



  }

}
