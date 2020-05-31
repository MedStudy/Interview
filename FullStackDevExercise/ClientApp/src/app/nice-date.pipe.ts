import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'niceDate'
})
export class NiceDatePipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): unknown {
    let date = new Date(value)
    console.log(date)
    let final = date.toLocaleDateString() //+ ' - '+ date.toLocaleTimeString()
    return final
  }

}
