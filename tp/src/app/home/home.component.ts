import { Component, OnInit } from '@angular/core';
import { DatasService } from '../datas.service';
import { Observable } from 'rxjs/Observable';
import { IntervalObservable } from 'rxjs/Observable/IntervalObservable';

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
  private display: boolean; // whether to display info in the component
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
  constructor(private dataSvc: DatasService) {
    this.display = false;
    this.alive = true;
  }

  ngOnInit() {
    this.SetQueryDay();
    if(this.getIsLogin()){
      this.SetLoginBtnStatus(false);
      this.showData();
    }else{
      this.InitView();
      //模擬User Click事件
      document.getElementById("btn_login").click();
    }
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnDestroy() {
    this.alive = false; // switches your IntervalObservable off
    if(this.service != null && this.service != undefined)
      this.service.unsubscribe();//取消訂閱
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
    //console.log("date:" + this.date);
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
    console.log("date:" + this.date);
    var datetxt = this.date.split("-");
    console.log("datetxt:" + datetxt);
    var mDate = "";
    for(var i = 0; i < datetxt.length;i++)
      mDate += datetxt[i];

    console.log("mDate:" + mDate);
    return mDate;
  }

  //判斷是不是查詢今天日期，不是就要取消訂閱更新資料
  GetIsToday(){
    var mNowDay = new Date(this.date);
    if(this.NowDay.getFullYear() == mNowDay.getFullYear()
        && this.NowDay.getMonth() == mNowDay.getMonth()
        && this.NowDay.getDate() == mNowDay.getDate())
      return true;
    else
      return false;
  }

  //查詢資料
  doquery(){
    if(!this.checkDateFormat())
    {
      alert("日期格式錯誤");
      return;
    }
    else
    {
      this.SetTimerForSubscribe();
      var mDate = this.GetDateTxt();
      this.dataSvc.getAllDatas(mDate)
      .subscribe(data => {
        this.datas = data;
        this.display = true;
      });
    }
  };

  //將畫面調整成未登入時的狀態
  InitView(){
    this.SetLoginBtnStatus(true);
    this.datas = null;
  }

  //iEnable : True = 顯示LoginBtn,隱藏LogOutBtn
  SetLoginBtnStatus(iEnable:boolean){
    if(iEnable){
      document.getElementById("btn_login").style.display = "block";
      document.getElementById("btn_logout").style.display = "none";
      document.getElementById("btn_link").style.display = "none";
    }else{
      document.getElementById("btn_login").style.display = "none";
      document.getElementById("btn_logout").style.display = "block";
      document.getElementById("btn_link").style.display = "block";
    }
  }

  logout() {
    if(this.service != null && this.service != undefined)
      this.service.unsubscribe();//取消訂閱

    localStorage.removeItem(this.token);
    this.InitView();
  }

  login() {
    this.dataSvc.getLogin(this.user.toLowerCase(),this.pws).subscribe(data => {
      if(data == "-1" ||data == "-2"){
        alert("帳戶驗證錯誤，請確認帳號密碼");
        return;
      }
      localStorage.setItem(this.token,data);
      this.SetLoginBtnStatus(false);
      this.showData();
    });
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
  SetTimerForSubscribe(){
    if(this.getIsLogin() && this.GetIsToday()){
      // get our data every subsequent 60 seconds 60000
      this.service = IntervalObservable.create(60000).subscribe(() => {
        if(this.checkDateFormat)
        {
          this.dataSvc.getAllDatas(this.GetDateTxt())
          .subscribe(data => {
            this.datas = data;
          });
        }
      });
    }else{
      if(this.service != null && this.service != undefined)
        this.service.unsubscribe();
    }
  }

  showData() {
    if(this.checkDateFormat())
    {
      this.dataSvc.getAllDatas(this.GetDateTxt())
      .subscribe(data => {
        this.datas = data;
        this.display = true;
      });
      this.SetTimerForSubscribe();
    }
  }
}
