import { Component, OnInit } from '@angular/core';
import { DatasService } from '../datas.service';

import {Router, ActivatedRoute} from '@angular/router';
@Component({
  selector: 'app-mccodelist',
  templateUrl: './mccodelist.component.html',
  styleUrls: ['./mccodelist.component.css']
})
export class MccodelistComponent implements OnInit {

  today: Date ;
  strYear: string = '';
  strMonth: string = '';
  strDay: string = '';
  strListClass: string = '';
  ListCodes: any[] = [];
  datas: any[] = [];
  code: string  ;
  codeSelected: string  ;
  date: string  ;



  constructor(public datasvc: DatasService, private router: Router, private route: ActivatedRoute ) {


   var time = new Date();

    //PM七點 日期加一
   if( time.getHours() >= 19 )
   {
    time.setDate(time.getDate()+1);
   }

   this.today = time;


    this.strYear = this.today.getFullYear().toString();

    this.strMonth = '';
    this.strDay = '';
    let tmpMonth = this.today.getMonth() + 1 ;
    let tmpDay = this.today.getDate();

    if (tmpMonth.toString().length > 1) {
      this.strMonth = tmpMonth.toString();
    }else {
      this.strMonth = '0'.concat(tmpMonth.toString());
    }

    if (tmpDay.toString().length > 1) {
      this.strDay = tmpDay.toString();
    }else {
      this.strDay = '0'.concat(tmpDay.toString());
    }


    this.date =  this.strYear.concat('-', this.strMonth, '-' , this.strDay);


    // console.log(this.date);

  }


  ngOnInit() {
    this.route.params.subscribe(params => {
      this.code = params['code'];
    });
    this.codeSelected = this.code;
    this.doquery();

  }


  doquery() {
    this.datas = [];
    this.ListCodes = [
        {val: 'FPC' , txt: 'FPC' },
        {val: 'TAC' , txt: 'TAC'},
        {val: 'POL' , txt: 'POL'},
        {val: 'AGAFP' , txt: 'AGAFP'}
    ];
    // console.log(this.codeSelected);

    this.code = this.codeSelected;

    this.datasvc.getAssmbingDetail( this.code , this.date.replace('-', '').replace('-', ''))
    .subscribe(data => {
      if ( data.length !== 0) {
        this.strListClass = 'col-md-'.concat( Math.ceil(12 / data.length + 1).toString()) ;
        // console.log( this.strListClass + '1');
      }
        this.datas = data;
    });

    // console.log( this.strListClass + '2');
  }




}
