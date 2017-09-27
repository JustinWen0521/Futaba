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
  code: String;
  date: String;

  constructor(private http: Http) { }

   // 抓取產線所有的資料
  getAllDatas(): Observable<any[]> {
    return this.http.get(`${this.target}` + `${this.allLineInfoUri}` )
    .map(res => res.json());
  }



  getAssmbingDetail(strCode , strDate): Observable<any[]> {
  //  return this.http.get('api/prd.json')
  //  .map(res => res.json());
      return this.http.get( ( `${this.target}` + `${this.AssmblingDetailUri }` + '?code=' + `${strCode}` +  '&date=' + `${strDate}` ) )
        .map(res => res.json());
  }


}

