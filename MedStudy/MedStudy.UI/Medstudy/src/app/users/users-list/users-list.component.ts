import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SharedService } from 'src/app/common/shared-service.service';
import { UserService } from '../user-service.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  public userSearch: any;
  states: any[] = [];
  columnDefs: any;
  rowModelType:any = "serverSide";
  serverSideStoreType:any = "partial";
  rowData: any[] = [];
  public gridApi: any;
  public gridColumnApi: any;
  public params:any;
  constructor(private sharedService: SharedService, private userService: UserService) {

  }

  ngOnInit(): void {
    this.loadConfigurations();
    this.loadStates();
  }

  loadConfigurations() {
    this.userSearch = new FormGroup(
      { 'firstName': new FormControl(), 'lastName': new FormControl(), 'year': new FormControl(), 'state': new FormControl('') }
    );
    this.columnDefs = [{ field: "employeeId" }, { field: "firstName" }, { field: "lastName" }, { field: "year" }, { field: "state" }, { field: "address1" }, { field: "address2" }, { field: "zipcode" }, { field: "country" }];
  }

  loadStates() {
    this.sharedService.getStates().subscribe(res => { this.states = res });
  }

  onGridReady(params: any) {
    this.gridApi = params.api;
    this.gridColumnApi = params.columnApi;
    this.params = params;
    params.api.setRowData(this.loadData());
    // let datasource = this.serverSideDatasource(this);
    // params.api.setServerSideDatasource(datasource);
  }

  search(){
    this.params.api.setRowData(this.loadData());
  }

  serverSideDatasource(server:any) {
    return {
      getRows: function (params:any) {
        var response = server.loadData();
        setTimeout(function () {
          if (response.success) {
            params.success({
              rowData: response,
              rowCount: response.length,
            });
          } else {
            params.fail();
          }
        }, 200);
      },
    };
  }

  loadData() {
    let inputObj: any = {
      firstName: this.userSearch.controls["firstName"].value,
      lastName: this.userSearch.controls["lastName"].value,
      state: this.userSearch.controls["state"].value,
      year: this.userSearch.controls["year"].value,
    };
    this.userService.getUsersList(inputObj).subscribe(res => {
      this.rowData = res;
    });
  }

}
