import { Component, OnInit } from '@angular/core';
import { DatasService } from '../datas.service';

import {Router, ActivatedRoute} from '@angular/router';
@Component({
  selector: 'app-mccodelist',
  templateUrl: './mccodelist.component.html',
  styleUrls: ['./mccodelist.component.css']
})
export class MccodelistComponent implements OnInit {

  datas;
  // code: String  = 'FPC';
  code: String ;
  date: String  = '20170914';

  constructor(public datasvc: DatasService ) { }


  ngOnInit() {
     this.doquery();

  }


  doquery() {


    this.datasvc.getAssmbingDetail( this.code , this.date)
    .subscribe(data => {
        this.datas = data;
    });
  }



}
