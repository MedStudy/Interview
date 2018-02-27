import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'limitTo'})
export class LimitToPipe implements PipeTransform {

  transform(value: Array<any>, limit: number = 10): Array<any> {
    return value.slice(0,limit);
  }

}
