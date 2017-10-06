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
  islogin: boolean = false;

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
    //////////
    console.log( "ngOnInit" +  document.cookie);
    if (document.cookie == "Y") {
      this.islogin = true;
      this.showData();
      //this.doquery();
      document.getElementById("btn_link").style.display = "block";
      document.getElementById("btn_login").style.display = "none";
      document.getElementById("btn_logout").style.display = "block";
    }
    else {
      //login();
      console.log('TODO login modal');
      document.getElementById("btn_login").style.display = "block";
      document.getElementById("btn_logout").style.display = "none";
    }

  }
  // tslint:disable-next-line:use-life-cycle-interface
  ngOnDestroy() {
    this.alive = false; // switches your IntervalObservable off
  }

  doquery() {
    console.log( "doquery" +  this.islogin);
    if (this.islogin) {
      this.logout();
    }
    else {
      this.login();
    }
  }

  logout() {
    document.cookie = '';
    this.islogin = false;
    document.getElementById("btn_link").style.display = "none";
    this.datas = null;

    document.getElementById("btn_login").style.display = "block";
    document.getElementById("btn_logout").style.display = "none";

  }

  login() {
    // if (this.islogin)
    //   return;
    console.log(this.pws);

    if (this.user.toLowerCase() != "tftp")
    {
      alert("帳密錯誤");
      return;
    }
    if (this.pws != "76025017") {
      alert("帳密錯誤");
      return;
    }
    document.cookie = "Y; path=/";
    //document.getElementById("btn_login").style.display="none";
    document.getElementById("btn_link").style.display = "block";
    document.getElementById("btn_login").style.display = "none";
    document.getElementById("btn_logout").style.display = "block";
    this.showData();



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
      if (this.islogin)
      {
        this.dataSvc.getAllDatas()
        .subscribe(data => {
          this.datas = data;
        });
      }
    });

  }

}
