import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/timeout';
import {Observable} from 'rxjs/Observable';
import {Http} from '@angular/http';

@Injectable()
export class DatasService {
  // WebAPI的uri
  private target = 'http://eip.tw-futaba.com.tw/FtbAssmbling' ;
  // private target = 'http://localhost/FtbAssmbling' ;
  private allLineInfoUri = '/Assmbling/GetProductLineInfo';
  AssmblingDetailUri = '/AssmblingDetail/GetAssemblingDetailByDate';
  private LoginUri = '/Assmbling/Login';
  code: String;
  date: String;

  constructor(private http: Http) { }

  getLogin(userName,userPws):Observable<string> {
    return this.http.get( ( `${this.target}` + `${this.LoginUri }` + '?iUsername=' + `${userName}` +  '&iPassWord=' + `${userPws}` ) )
    .map(res => res.text());
  }

   // 抓取產線所有的資料
  getAllDatas(selectDate): Observable<any[]> {
    return this.http.get(`${this.target}` + `${this.allLineInfoUri}`
                        + '?itoken=' + localStorage.getItem("token")
                        + '&Id=' + ''
                        + '&iselectDate=' + `${selectDate}`)
                        .map(res => res.json());
  }

  getAssmbingDetail(strCode , strDate): Observable<any[]> {
  //  return this.http.get('api/prd.json')
  //  .map(res => res.json());
      return this.http.get( ( `${this.target}` + `${this.AssmblingDetailUri }` + '?code=' + `${strCode}` +  '&date=' + `${strDate}` ) )
        .map(res => res.json());
  }

// 轉換日期的格式
getDateFormat(dte: Date , type: string): any {
  let result: any;
  let strYear = dte.getFullYear().toString();
  let strMonth = this.getFullZero( dte.getMonth() + 1 );
  let strDay = this.getFullZero( dte.getDate() );
  let strHour = this.getFullZero( dte.getHours());
  let strMinute = this.getFullZero( dte.getMinutes() );
  let strSecond = this.getFullZero( dte.getSeconds() );

  switch (type) {
    case 'yyyy-MM-dd':
    result = strYear.concat('-', strMonth, '-' , strDay);
    break;
    case 'yyyy-MM-dd HH:mm:ss':
    result = strYear.concat('-', strMonth, '-' , strDay) + ' ' + strHour.concat(':', strMinute, ':', strSecond);
    break;
    case 'MM/dd HH:mm:ss':
    result = strMonth.concat('/',  strDay) + ' ' + strHour.concat(':', strMinute, ':', strSecond);
    break;
    default:
    result = '';
  }

  return result;

}

// 日期補0
getFullZero(data: number): string {
  if (data.toString().length > 1) {
    return data.toString();
  }else {
    return '0'.concat(data.toString());
  }
}

// 下拉式選單
getSelectOptions() {
  let selectGroups = [];
  let options = [
    {val: 'FPC' , txt: 'FPC'  },
    {val: 'TAC' , txt: 'TAC' },
    {val: 'POL' , txt: "偏光板"  },
    {val: 'AGAFP' , txt: 'AGAFP' }
  ];
  selectGroups['MCCodeOptions'] = options;
  return selectGroups;
}


//檢查日期是否符合區間(HTML5的date屬性，先暫定這樣處理)
CheckDateFormat(date:string):boolean {
  let iDate = date.split("-");
  if(iDate.length != 3)
    return false;

  let mYear = parseInt(iDate[0]);
  let mMonth = parseInt(iDate[1]);
  let mDay = parseInt(iDate[2]);

  if(mYear < 2010) {
    return false;
  }

  if(mMonth < 1 || mMonth > 12) {
    return false;
  }

  if(mDay < 1 || mDay > 31) {
    return false;
  }
  return true;
}


}

