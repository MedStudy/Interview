import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { petsListModel, petsModel } from 'src/app/models/pets';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css'],
})
export class PetListComponent implements OnInit {
  submitted: boolean = false;
  _petsModel: petsListModel[] = [new petsListModel()];

  constructor(
    private crudservice: CrudServiceService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fetpets();
  }
  fetpets() {
    this._petsModel = [];
    this.crudservice.getpets().subscribe(
      (response: any) => {
        this._petsModel = response;
        this.submitted = true;
      },
      (error) => {
        this.submitted = false;
        alert('Something went wrong!!');
      }
    );
  }
  edit(id: number) {
    this.router.navigate(['/petedit', id]);
  }
  delete(id: number) {
    let a = confirm('Are you sure, you want to delete pet with id=' + id);
    if (a) {
      this.crudservice.deleteparticularpets(id).subscribe(
        (response: any) => {
          this.submitted = false;
          this.fetpets();
          alert('Pet deleted successfully !!');
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
