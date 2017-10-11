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

  user: string;
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

  token:string = "token";

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
    if(this.getIsLogin()){
      this.SetLoginBtnStatus(false);
      this.showData();
    }else{
      this.InitView();
      document.getElementById("btn_login").click();
    }
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnDestroy() {
    this.alive = false; // switches your IntervalObservable off
  }

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

  showData() {
    this.dataSvc.getAllDatas()
    .subscribe(data => {
      this.datas = data;
      this.display = true;
    });

  // get our data every subsequent 60 seconds
  IntervalObservable.create(60000)
    .subscribe(() => {
      if(this.getIsLogin())
      {
        this.dataSvc.getAllDatas()
        .subscribe(data => {
          this.datas = data;
        });
      }
    });
  }
}
