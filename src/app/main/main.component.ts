import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { MainService } from './main.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  list: Observable<any>;

  constructor(private _ms:MainService) { }

  ngOnInit() {
  }

  getData(id:string){

    if(id){
      this._ms.getUsers(id)
        .subscribe(response => this.handleSucess(response), response => this.handleError(response));
    }

  }

  private handleSucess(response: Observable<any>): void{

    this.list = response;

  }

  private handleError(response: any): void{

    console.log('handleError');

  }

}
