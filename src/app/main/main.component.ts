import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs/Observable';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  constructor(private http:HttpClient) {}

  public users: string[];
  public user: string;
  public totalCount: any;

  ngOnInit() {
    let users = [];
    let totalCount = null;
  }

  public getUsers() {
      window.console.log("Here");
      this.http.get('https://api.github.com/search/users?q=' + this.user)
      .subscribe(
        (data: any) => {
            this.users = data.items;
            this.totalCount = data.total_count;
            window.console.log(JSON.stringify(this.users);
        },
        err => console.error(err),
        () => console.log('done')
      );
  }

}
