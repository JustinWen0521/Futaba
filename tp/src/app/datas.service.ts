import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map'
import {Observable} from 'rxjs/Observable';
import {Http} from '@angular/http';

@Injectable()
export class DatasService {

//WebAPI的uri
private allLineInfoUri= '/Assmbling/GetAllLineInfo';

  constructor(private http:Http) { }

   //抓取產線所有的資料
  getAllDatas(): Observable<any[]>{

    return this.http.get(this.allLineInfoUri)
           .map(res => res.json());

  }

}
