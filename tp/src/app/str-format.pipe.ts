import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'strFormat'
})
export class StrFormatPipe implements PipeTransform {

  resultname: any;
  transform(value: string, seperator: string): string {
    // 判斷字串是否為空
    if (value.length === 0) {
      this.resultname = '未定義';
    }else {
      this.resultname = value;
    }
    return this.resultname;
  }

}
