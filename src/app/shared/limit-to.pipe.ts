import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'limitTo'})
export class LimitToPipe implements PipeTransform {

  transform(value: Array, limit: Number = 10): Array {
    return value.slice(0,limit);
  }

}
