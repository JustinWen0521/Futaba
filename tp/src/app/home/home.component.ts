import { Component, OnInit, Input } from '@angular/core';
import { DatasService } from '../datas.service';
import { Observable } from 'rxjs/Observable';
import { IntervalObservable } from 'rxjs/Observable/IntervalObservable';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  //User Key In 帳號
  user: string;
  //User Key In 密碼
  pws: string;
  datas: any;
  testwidth: any;
  // futaba圖片放置路徑
  futaba = {
    name: 'Futaba',
    picture: 'assets/icons/futaba.jpg'
  };
  //private display: boolean; // whether to display info in the component
  // use *ngIf="display" in your html to take
  // advantage of this

  private alive: boolean; // used to unsubscribe from the IntervalObservable

  isCollapsed: boolean = true;
  //用來存API回傳的token key,存放在localStorage
  token:string = "token";
  //User Select Date,預設今天日期(晚上8點後會自動加一天)
  date:string;
  //目前今天日期(過晚上8點會加一天)
  NowDay:Date;
  //訂閱自動更新
  service:any;
  //自動更新日期服務
  updateService:any;
  //目前是全部展開或收折，預設全部展開(True)
  toggleStatus:boolean = true;
  //最後更新時間
  lastUpdateTime:Date;
  //收折按鈕名稱
  btnName:string="toggleBtn";
  //每條線上一層DIV名稱
  divName:string="oneDiv";
  //是否自動更新(checkBox),預設開啟
  IsAuto:boolean=true;
  //自動更新時間
  UpdateTime:number=60000;
  //每條線別狀態(開啟或收折)
  toggleList:boolean[];
  //建立線別上層
  lineNumber:number[];

  toggleCollapse(): void {
    this.isCollapsed = !this.isCollapsed;
  }

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
  constructor(private dataSvc: DatasService,private router: Router) {
    //this.display = false;
    this.alive = true;
  }

  ngOnInit() {
    this.SetQueryDay();
    if(this.IsAuto)
      this.SubscribeUpdateEverySingleDay();

    if(this.getIsLogin()){
      this.showData();
    }else{
      this.router.navigateByUrl('/Login');
    }
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnDestroy() {
    this.alive = false; // switches your IntervalObservable off
    if(this.service != null && this.service != undefined)
      this.service.unsubscribe();//取消訂閱

    if(this.updateService != null && this.updateService != undefined)
      this.updateService.unsubscribe();//取消檢查更新
  }

  //設定查詢日期
  SetQueryDay(){
    this.NowDay = new Date();

    //大於晚上7點日期加1
    if(this.NowDay.getHours() > 19)
    {
      this.NowDay.setDate(this.NowDay.getDate()+1);
    }

    let mYear = this.NowDay.getFullYear();
    var mMonth = (this.NowDay.getMonth() + 1).toString();
    var mDay = this.NowDay.getDate().toString();

    //月份只有個位數時要補0
    if (mMonth.length == 1) {
      mMonth = '0'.concat(mMonth.toString());
    }
    //日期只有個位數時要補0
    if (mDay.length == 1) {
      mDay = '0'.concat(mDay.toString());
    }
    this.date = mYear + "-" + mMonth + "-" + mDay;
  }

  //檢查日期格式
  checkDateFormat(){
    var datetxt = this.GetDateTxt();
    if(datetxt.length != 8)//日期格式會有8位元，(ex:20171231)
      return false;
    else
      return true;
  }

  //組合日期格式(去掉符號)
  GetDateTxt(){
    var datetxt = this.date.split("-");
    var mDate = "";
    for(var i = 0; i < datetxt.length;i++)
      mDate += datetxt[i];

    return mDate;
  }

  //查詢資料
  doquery(){
    if(!this.dataSvc.CheckDateFormat(this.date))
      return;

    if(!this.checkDateFormat())
    {
      //alert("日期格式錯誤");
      return;
    }
    else
    {
      if(this.IsAuto) {
        this.IsAuto = false;
        this.SelectAutoStatus();
      }
      this.GetAllDatas();
    }
  };

  //點擊展開收折鈕
  OnButtonClick(index:any) {
    if(this.toggleList[index])
      this.toggleList[index] = false;
    else
      this.toggleList[index] = true;

    $('#' + index).toggle('slow');
    this.OnCheckLineStatus();
  }

  //點擊全展開或收折
  AllLineChangeToggle() {
    let mLineNumber = this.datas.length;
    for(var i = 0;i <= mLineNumber;i++) {
      if(this.toggleStatus) {//true:表示目前線別是展開的，接下來要進行收折動作
        if($('#' + i).is(':visible')) {//判斷各線目前是否是展開的，是展開的才進行收折
          $('#' + i).toggle('slow');
        }
      }else {//true:表示目前線別是收折的，接下來要進行展開動作
        if(!$('#' + i).is(':visible')) {//判斷各線目前是否是收折的，是收折的才進行展開
          $('#' + i).toggle('slow');
        }
      }
    }
    this.toggleStatus = this.toggleStatus == true ? false : true;//展闕收折完後變更狀態
    this.InitToggleStatus(this.toggleStatus);
    if(this.toggleStatus) {//目前狀態是展開，下一個動作要準備進行收折
      $('#ToggleBtn').html("全部收折");
    }
    else {
      $('#ToggleBtn').html("全部展開");
     }
  }

  //return True = IsLogin,False = NotLogin
  getIsLogin(){
    var mToken = localStorage.getItem("token");
    if(mToken != '-1' && mToken != '-2' && mToken != null && mToken != undefined)
      return true;
    else
      return false;
  }

  //設定是否訂閱更新資料，有登入拿到token & 是今天才訂閱更新，否則取消訂閱
  SetTimerForSubscribe(iAuto:boolean){
    if(iAuto) {
      this.service = IntervalObservable.create(this.UpdateTime).subscribe(() => {
        if(this.checkDateFormat())
        {
          this.GetAllDatas();
        }
      });
    }else {
      if(this.service != null && this.service != undefined)
        this.service.unsubscribe();
    }
  }

  //取資料
  showData() {
    if(this.checkDateFormat())
    {
      this.GetAllDatas();
      this.SetTimerForSubscribe(this.IsAuto);
    }
  }

  //呼叫API取資料
  GetAllDatas() {
    this.dataSvc.getAllDatas(this.GetDateTxt())
    .subscribe(data => {
      if(data == null || data == undefined || data.length < 1) {
        this.datas = [];//無資料，變空白
        this.lineNumber = null;
        this.toggleList = null;
      }
      else {
        this.datas = data;
        if(this.lineNumber == null || this.lineNumber == undefined || this.lineNumber != this.datas.length)//只有第一次會進來or線別總數不同時，建立上層DIV
        {
          this.lineNumber = [];
          for(var i =0;i < data.length;i++)
            this.lineNumber.push(i);
        }

        if(this.toggleList == null || this.toggleList == undefined || this.toggleList != this.datas.length) {//只有第一次會進來or線別總數不同時，建立收折開關狀態
          this.toggleList = [];
          for(var i = 0; i < this.datas.length; i++) {
            this.toggleList.push(true);
          }
        }
      }
      this.lastUpdateTime=this.dataSvc.getDateFormat(new Date() , 'MM/dd HH:mm:ss');
    });
  }

  //設定是否啟用自動更新
  SelectAutoStatus() {
    this.SubscribeUpdateEverySingleDay();
    if(this.IsAuto)
    {
      this.SetQueryDay();
      this.showData();
    }else {
      this.SetTimerForSubscribe(this.IsAuto);
    }
  }

  //檢查日期，處理誇日問題日期要自動加一天
  SubscribeUpdateEverySingleDay() {
    if(this.IsAuto) {
      this.updateService = IntervalObservable.create(1000).subscribe(() => {
        let mNowDay = new Date();
        let mNowDayTxt = mNowDay.getFullYear().toString() + (mNowDay.getMonth() + 1).toString() + mNowDay.getDate().toString();
        let InputBoxDay = this.GetDateTxt();
        if(parseInt(InputBoxDay) < parseInt(mNowDayTxt))
          this.SetQueryDay();
      });
    }else {
      if(this.updateService != null && this.updateService != undefined)
        this.updateService.unsubscribe();//取消檢查更新
    }
  }

  //檢查是否全部收折或展開，更改文字按鈕
  OnCheckLineStatus() {
    let mOpen = 0;
    let mClose = 0;
    for(var i = 0;i < this.toggleList.length;i++) {
      if(this.toggleList[i])
        mOpen++;
      else
        mClose++;
    }

    if(mOpen == this.datas.length) {
      $('#ToggleBtn').html("全部收折");
      this.toggleStatus = true;
    }

    if(mClose == this.datas.length) {
      $('#ToggleBtn').html("全部展開");
      this.toggleStatus = false;
    }
  }

  //初始化收折按鈕狀態，全開或全關使用
  InitToggleStatus(iStatus:boolean) {
    if(this.toggleList != null && this.toggleList != undefined) {
      for(var i = 0; i < this.toggleList.length;i ++)
        this.toggleList[i] = iStatus;
    }
  }
}
