import { Component, OnInit } from '@angular/core';
import { DatasService } from '../datas.service';
@Component({
  selector: 'app-page1',
  templateUrl: './page1.component.html',
  styleUrls: ['./page1.component.css']
})
export class Page1Component implements OnInit {

    datas:any;
    testwidth: any;
    
     futaba = {  
      name: "Futaba",  
      picture: "/assets/icons/futaba.jpg"  
     };  
   
  onResize(event) {      
      this.testwidth = event.target.innerWidth;
   }

   getCSSClasses(flag:string) {
    let cssClasses;
    if(flag == '1024') {  
         cssClasses = {
      'productTitle1024': true
   }	
    } else {  
         cssClasses = {
      'two': true,
      'four': false 
   }	
    }
    return cssClasses;
 }	

   constructor(private dataSvc: DatasService){
   }

   ngOnInit() {
    this.dataSvc.getAllDatas()
    .subscribe( data=>{
       this.datas=data;
    });
  }
}
