import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import {HttpClient} from '@angular/common/http';


@Component({
  selector: "app-view-owners",
  templateUrl: "./view-owners.component.html",
  styleUrls: ["./view-owners.component.css"]
})
export class ViewOwnerComponent implements OnInit {
  dataSource: any = [];
  displayedColumns: any;
  constructor(
    private router: Router,
    private httpClient: HttpClient

  ) {
  }

  ngOnInit() {
    this.viewOwner();
  }

  deleteOwner(id) {

    this.httpClient.delete('https://localhost:5001/api/owner/' + id, {observe: 'response'}).subscribe(data => {
      if (data['status'] === 200) {
        window.alert("Deleted " + id);
        this.ngOnInit();
      } else {
        window.alert("fail"); }});
  }

  viewOwner() {

    this.getCustomer().subscribe(data => {
      if (data['status'] === 200) {
        this.dataSource = data["body"];
      } else {
        window.alert("fail");
      }
    });

  }
 
  public getCustomer(){
    return this.httpClient.get('https://localhost:5001/api/owner', {observe: 'response'});
  }
}
