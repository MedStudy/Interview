import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ownersModel } from 'src/app/models/ownerModel';
import { petsModel } from 'src/app/models/pets';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-editpet',
  templateUrl: './editpet.component.html',
  styleUrls: ['./editpet.component.css'],
})
export class EditpetComponent implements OnInit {
  submitted: boolean = false;
  _petsModel: petsModel = new petsModel();
  _ownersmodel: ownersModel = new ownersModel();
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private crudservice: CrudServiceService
  ) {}

  ngOnInit(): void {
    this.fetchpet(parseInt(this.route.snapshot.paramMap.get('id')));
  }
  fetchpet(id: number) {
    this._petsModel = new petsModel();
    this.crudservice.getowners().subscribe((rr: any) => {
      this._ownersmodel = rr;
      this.crudservice.getparticularpets(id).subscribe(
        (response: any) => {
          this._petsModel = response;
        },
        (error) => {
          alert('Something went wrong!!');
        }
      );
    });
  }
  viewlist() {
    this.router.navigate(['/pets']);
  }
  editpet() {
    this.submitted = false;
    this._petsModel.age = parseInt(this._petsModel.age.toString());
    this._petsModel.owner_id = parseInt(this._petsModel.owner_id.toString());
    this.crudservice.updatepet(this._petsModel).subscribe(
      (response: any) => {
        this.submitted = true;
      },
      (error) => {
        this.submitted = false;
        alert('Something went wrong!!');
      }
    );
  }
}
