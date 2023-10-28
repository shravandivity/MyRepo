import { Pipe, PipeTransform } from '@angular/core';
import { Project } from './project';

@Pipe({
  name: 'paging'
})
export class PagingPipe implements PipeTransform {

  transform(value: Project[], currentPageIndex:number, pageSize:number): any {
   
    if(value == null)
    {
      return null;
    }
    let resultArray=[];
    for(let i = currentPageIndex * pageSize; i < ((currentPageIndex + 1) * pageSize); i++)
    {
      //console.log("i: " + i);
      if(value[i])
      {
        resultArray.push(value[i]);
      }
    }
    //console.log("result cnt: " + resultArray.length);
    return resultArray;
  }

}
