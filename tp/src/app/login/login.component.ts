import { Component, OnInit } from '@angular/core';
import { DatasService } from '../datas.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  Account : string;
  password : string;
  token:string = "token";

  constructor(private dataSvc: DatasService,private router : Router) { }

  ngOnInit() {
  }

  doLogin() {
    this.dataSvc.getLogin(this.Account.toLowerCase(),this.password).subscribe(data => {
      if(data == "-1" ||data == "-2") {
        alert("帳戶驗證錯誤，請確認帳號密碼");
        return;
      }else {
        localStorage.setItem(this.token,data);
        this.router.navigateByUrl('/home');
      }
    });
  }


}
