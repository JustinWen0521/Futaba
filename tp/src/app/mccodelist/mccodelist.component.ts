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

  today: string;
  nowDate: Date;// 顯示的更新時間
  strListClass: string = '';
  ListCodes: any[] = [];//品種選單
  code: string;//Title
  OptionsPool: any[];// 下拉式選單
  datas: any[] = []; // 篩選的資料
  codeSelected: string; // 品種
  date: string; // 日期
  service: any; // 訂閱自動更新
  id1: string ; // 開合(table)
  id2: string ; // 開合(button)
  id2All: string;
  timer: number; // 計數器
  IsAuto:boolean;//是否自動更新



  constructor(public datasvc: DatasService, private router: Router, private route: ActivatedRoute ) {
    this.initSelectedDate();
    this.date = this.today;
    this.OptionsPool = this.datasvc.getSelectOptions();
    this.ListCodes = this.OptionsPool['MCCodeOptions'];
    this.id1 = 'table_mccode_'; // 開合
    this.id2 = 'button_mccode_'; // 開合
    this.id2All = 'button_mccode_all'; // 開合
    this.IsAuto = true;

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.codeSelected = params['code'];
    });
    this.isCloseAuto();

  }

  // Template完成後執行
  ngAfterViewInit() {
    // PrepareUI();
  }
  // 離開頁面取消訂閱事件
  ngOnDestroy() {
    if (this.service) {
        this.service.unsubscribe();
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

  // 專門給 ngFor 用的陣列屬性
 get data_mccode_len() {
    return new Array(this.datas.length);
  }

  // 回首頁
  rebackView() {
    this.router.navigate(['/home']);
  }

  doquery() {
    if(!this.datasvc.CheckDateFormat(this.date))
      return;

    let dateTmp: string;
    this.code = this.ListCodes.filter(item => item.val === this.codeSelected)[0].txt;
    dateTmp = this.date.replace('-', '').replace('-', '');
    this.datasvc.getAssmbingDetail( this.codeSelected , dateTmp)
    .subscribe(data => {
        if ( data.length) {
          this.strListClass = 'col-md-'.concat( Math.ceil(12 / data.length + 1).toString()) ;
          this.datas = data;
        //if (this.today === this.date) {
          this.nowDate = this.datasvc.getDateFormat(new Date() , 'MM/dd HH:mm:ss');
        //}
        this.timer = 0;
        this.setTimerForToggleAll();
      }
      else {
        this.datas = [];
      }
    });
  }


  // 是否要取消自動更新
  isCloseAuto() {
    if (this.IsAuto) {
      this.SetTimerForSubscribe(true);
    } else {
      this.SetTimerForSubscribe(false);
    }
  }


  // 設定是否訂閱更新資料
  SetTimerForSubscribe(isWork: boolean) {
    if (isWork) {
      this.initSelectedDate();
      this.date = this.today;
      this.doquery();

      // get our data every subsequent 60 seconds 60000
      this.service = IntervalObservable.create(10000).subscribe(() => {
          this.initSelectedDate();
          this.date = this.today;
          this.doquery();
        });
    }
    else {
        if (this.service) {
          this.service.unsubscribe();
        }
    }
  }

  // 預設把選取的資料先關閉不顯示
  setTimerForToggleAll() {
    let ToggleInterval = setInterval(()=>{
      let DOMTable = $('#' + this.id1 + 0 );
      this.timer++;
      if(DOMTable) {
        $('#' + this.id2All).html("全部收折");
        clearInterval(ToggleInterval);
        this.jqueryToggleAll(this.id1 , this.id2);
        // $('#' + this.id2All ).trigger('click');
      }
      //太久就關閉吧
      if(this.timer > 1000 && ToggleInterval) {
        clearInterval(ToggleInterval);
      }
   },100);
  }

  // 各項折合
  jqueryToggle(id_1 , id_2 ) {
    let id1Name = this.id1;
    let id1total:number = 0;
    let id1target =  $('#' + id_1);
    id1target.toggle(500);

    this.datas.forEach(function(val, index , ar){
      let id1display =  $('#' + id1Name + index).css('display');
      if(id1display != "none" ){
        id1total++;
      }
      // Template 尚未更新，會保留原先的部分!!
      if(id1target.css('display') == "none" ){
        id1total++;
      }
    });
    if(id1total == this.data_mccode_len.length){
        $('#' + this.id2All).html("全部收折");
    }
    if(id1total == 1) {
      $('#' + this.id2All).html("全部展開");
    }

  }

  // 全部關閉or開啟
  jqueryToggleAll(id_1 , id_2) {
    let btnVal = $('#' + this.id2All).html();
    if (btnVal.match("展開") ) {
      this.datas.forEach(function(val, index , ar) {
            $('#' + id_1 + index).show();
        });
        $('#' + this.id2All).html("全部收折");
    }
    if (btnVal.match("收折") ){
      this.datas.forEach(function(val, index , ar) {
          $('#' + id_1 + index).hide();
        });
        $('#' + this.id2All).html("全部展開");
    }
  }

}

