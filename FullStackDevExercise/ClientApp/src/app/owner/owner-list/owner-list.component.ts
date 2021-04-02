import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ownersModel } from 'src/app/models/ownerModel';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css'],
})
export class OwnerListComponent implements OnInit {
  submitted: boolean = false;
  _ownersModel: ownersModel[] = [new ownersModel()];

  constructor(
    private crudservice: CrudServiceService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fetchowners();
  }
  fetchowners() {
    this._ownersModel = [];
    this.crudservice.getowners().subscribe(
      (response: any) => {
        this._ownersModel = response;
        this.submitted = true;
      },
      (error) => {
        this.submitted = false;
        alert('Something went wrong!!');
      }
    );
  }
  edit(id: number) {
    this.router.navigate(['/owneredit', id]);
  }
  delete(id: number) {
    let a = confirm('Are you sure, you want to delete owner with id=' + id);
    if (a) {
      this.crudservice.deleteparticularowners(id).subscribe(
        (response: any) => {
          this.submitted = false;
          this.fetchowners();
          alert('Owner deleted successfully !!');
        },
        (error) => {
          this.submitted = false;
          alert('Something went wrong!!');
        }
      );
    } else {
      // user cancel the delete operation
    }
  }
}
