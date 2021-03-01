import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'arrayFirstOrDefault'
})
export class ArrayFirstOrDefaultPipe implements PipeTransform {

  transform(items: any[], key: number): any {
    if (!items || !key) {
      return null;
    }
    // filter items array, items which match and return true will be
    // kept, false will be filtered out
    let result = items.filter(item => item.id == key);
    return result.length > 0 ? result[0] : null;
  }

}
