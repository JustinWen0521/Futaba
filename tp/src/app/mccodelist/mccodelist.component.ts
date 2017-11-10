import { Component, OnInit,  AfterViewInit } from '@angular/core';
import { DatasService } from '../datas.service';

import {Router, ActivatedRoute} from '@angular/router';
import { IntervalObservable } from 'rxjs/Observable/IntervalObservable';

@Component({
  selector: 'app-mccodelist',
  templateUrl: './mccodelist.component.html',
  styleUrls: ['./mccodelist.component.css']
})
export class MccodelistComponent implements OnInit, AfterViewInit {

  today: Date ;
  nowDate: Date;
  strListClass: string = '';
  ListCodes: any[] = [];
  ListAutos: any[] = [];
  code: string;
  OptionsPool: any[];
  datas: any[] = []; // 篩選的資料
  codeSelected: string; // 品種
  autoSelected: string; //  是否要更新
  date: string; // 日期
  service: any; // 自動更新
  service1: any; // 自動更新(for toggle)
  id1: string ; // 開合(table)
  id2: string ; // 開合(button)
  id2All: string;
  timer: number; // 計數器


  constructor(public datasvc: DatasService, private router: Router, private route: ActivatedRoute ) {
    this.initSelectedDate();
    this.OptionsPool = this.datasvc.getSelectOptions();
    this.ListCodes = this.OptionsPool['MCCodeOptions'];
    this.ListAutos = this.OptionsPool['AutoOptions'];
    this.autoSelected = 'work';
    this.id1 = 'table_mccode_'; // 開合
    this.id2 = 'button_mccode_'; // 開合
    this.id2All = 'button_mccode_all'; // 開合
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.codeSelected = params['code'];
    });
    this.isCloseAuto();
    this.doquery();
  }

  // Template完成後執行
  ngAfterViewInit() {
    // $('#' + this.id2 + 'all' ).trigger('click');
  }


  // 取即時日期
  initSelectedDate() {
    this.today = new Date();
    // PM七點 日期加一
    if ( this.today.getHours() >= 19 ) {
      this.today.setDate(this.today.getDate() + 1);
    }
    this.date = this.datasvc.getDateFormat(this.today , 'yyyy-MM-dd');
  }


  doquery() {
    this.datas = [];
    this.code = this.ListCodes.filter(item => item.val === this.codeSelected)[0].txt;
    this.datasvc.getAssmbingDetail( this.codeSelected , this.date.replace('-', '').replace('-', ''))
    .subscribe(data => {
      if ( data.length !== 0) {
        this.strListClass = 'col-md-'.concat( Math.ceil(12 / data.length + 1).toString()) ;
      }
        this.datas = data;
        this.nowDate = this.datasvc.getDateFormat(new Date() , 'yyyy-MM-dd HH:mm:ss');
        this.timer = 0;
        this.setTimerForToggleAll();

    });

  }

  // 專門給 ngFor 用的陣列屬性
 get data_mccode_len() {
      return new Array(this.datas.length);
  }

  // 回首頁
  rebackView() {
    this.router.navigate(['/home']);
  }

  // 是否要取消自動更新
  isCloseAuto() {
    console.log(this.autoSelected);
    if (this.autoSelected === 'work') {
      this.SetTimerForSubscribe(true);
    } else {
      this.SetTimerForSubscribe(false);
    }
  }

  // 設定是否訂閱更新資料
  SetTimerForSubscribe(isWork: boolean) {
    if (isWork) {
      // get our data every subsequent 60 seconds 60000
      this.service = IntervalObservable.create(60000).subscribe(() => {
          this.initSelectedDate();
          this.doquery();
        });
    }else {
        if (this.service) {
          this.service.unsubscribe();
        }
    }
  }

  // 預設把選取的資料先關閉不顯示
  setTimerForToggleAll() {
    this.service1 = IntervalObservable.create(10).subscribe(() => {
      let DOMTable = $('#' + this.id1 + 0 );
      if (DOMTable) {

        $('#' + this.id2 + 'all' ).html("全部收折");
        $('#' + this.id2 + 'all' ).trigger('click');
        if (this.service1) {
          this.service1.unsubscribe();
        }

        this.timer ++;
      }
      if ( this.timer > 600000) {
        if (this.service1) {
          this.service1.unsubscribe();
        }
      }
    });


  }


  jqueryToggle(id_1 , id_2) {
    /*
      let btnVal = $('#' + id_2).html();
      if ( btnVal.match("開啟")) {
        $( '#' + id_1 ).show();
         $( '#' + id_2 ).html("關閉");
      }else {
        $( '#' + id_1 ).hide();
         $( '#' + id_2 ).html("開啟");
      }
      */
      $( '#' + id_1 ).toggle();
  }

  // 全部關閉or開啟
  jqueryToggleAll(id_1 , id_2) {
    let btnVal = $('#' + this.id2All).html();
    if (btnVal.match("開啟") ) {
      this.datas.forEach(function(val, index , ar) {
            $('#' + id_1 + index).show();
            // $('#' + id_2 + index ).html("關閉");
        });
        $('#' + this.id2All ).html("全部收折");
    }else {
      this.datas.forEach(function(val, index , ar) {
          $('#' + id_1 + index).hide();
          // $('#' + id_2 + index ).html("開啟");
        });
        $('#' + this.id2All ).html("全部開啟");
    }
  }

}

