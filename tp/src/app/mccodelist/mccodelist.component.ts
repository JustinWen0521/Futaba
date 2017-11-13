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

  today: string ;
  nowDate: Date;
  strListClass: string = '';
  ListCodes: any[] = [];
  code: string;
  OptionsPool: any[];
  datas: any[] = []; // 篩選的資料
  codeSelected: string; // 品種
  date: string; // 日期
  service: any; // 自動更新
  service1: any; // 自動更新(for toggle)
  id1: string ; // 開合(table)
  id2: string ; // 開合(button)
  id2All: string;
  id2name: string;
  timer: number; // 計數器


  constructor(public datasvc: DatasService, private router: Router, private route: ActivatedRoute ) {
    this.initSelectedDate();
    this.date = this.today;
    this.OptionsPool = this.datasvc.getSelectOptions();
    this.ListCodes = this.OptionsPool['MCCodeOptions'];
    this.id1 = 'table_mccode_'; // 開合
    this.id2 = 'button_mccode_'; // 開合
    this.id2All = 'button_mccode_all'; // 開合
    this.id2name = "全部收折" ;
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.codeSelected = params['code'];
    });
    this.isCloseAuto(true);
    this.doquery();
  }

  // Template完成後執行
  ngAfterViewInit() {
    // PrepareUI();
  }
  // 離開頁面取消訂閱事件
  ngOnDestory() {
    if (this.service) {
        this.service.unsubscribe();
    }

    if (this.service1) {
      this.service1.unsubscribe();
    }
  }

  //  =====================================================================================================================
  // 取即時日期
  initSelectedDate() {
    let todayDate = new Date();
    // PM七點 日期加一
    if ( todayDate.getHours() >= 19 ) {
      todayDate.setDate(todayDate.getDate() + 1);
    }
    this.today = this.datasvc.getDateFormat(todayDate, 'yyyy-MM-dd');
  }


  doquery() {
    // this.datas = [];
    let p_chkAuto = $('#chkAuto').prop('checked');
    this.setCheckBoxForAutos();
    let dateTmp: string;
    this.code = this.ListCodes.filter(item => item.val === this.codeSelected)[0].txt;
    dateTmp = this.date.replace('-', '').replace('-', '');
    this.datas = [];
    this.datasvc.getAssmbingDetail( this.codeSelected , dateTmp)
    .subscribe(data => {
        if ( data.length) {
          this.strListClass = 'col-md-'.concat( Math.ceil(12 / data.length + 1).toString()) ;
          this.datas = data;
        if (this.today === this.date) {
          this.nowDate = this.datasvc.getDateFormat(new Date() , 'MM/dd HH:mm:ss');
        }
      }
      // else {
      //   this.datas = [];
      // }

        this.timer = 0;
        this.setTimerForToggleAll();
    });
  }

  // 檢查是否查詢歷史記錄，須將自動更新關閉!!
  setCheckBoxForAutos() {
    let p_chkAuto = $('#chkAuto').prop('checked');
    this.initSelectedDate();
    if (this.today !== this.date &&  p_chkAuto !== false ) {
      $('#chkAuto').prop('checked' , false);
      this.isCloseAuto(false);
    }
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
  isCloseAuto(p_IsAuto: boolean) {
    if (p_IsAuto) {
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
          this.date = this.today;
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
    this.service1 = IntervalObservable.create(1).subscribe(() => {
      let DOMTable = $('#' + this.id1 + 0 );
      if (DOMTable) {
        $('#' + this.id2All ).trigger('click');
        this.timer ++;
      }

      if (DOMTable) {
        if (this.service1) {
          this.service1.unsubscribe();
        }
      }

    });

  }

  // 各項折合
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
      $( '#' + id_1 ).toggle(500);
  }

  // 全部關閉or開啟
  jqueryToggleAll(id_1 , id_2) {
    let btnVal = $('#' + this.id2All).html();
    if (btnVal.match("展開") ) {
      this.datas.forEach(function(val, index , ar) {
            $('#' + id_1 + index).show();
        });
        this.id2name = "全部收折";
    }else {
      this.datas.forEach(function(val, index , ar) {
          $('#' + id_1 + index).hide();
        });
        this.id2name = "全部展開";
    }
  }

}

