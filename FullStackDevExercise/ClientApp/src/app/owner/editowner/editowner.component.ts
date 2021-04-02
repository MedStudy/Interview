import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ownersModel } from 'src/app/models/ownerModel';
import { CrudServiceService } from 'src/app/services/crud-service.service';

@Component({
  selector: 'app-editowner',
  templateUrl: './editowner.component.html',
  styleUrls: ['./editowner.component.css'],
})
export class EditownerComponent implements OnInit {
  submitted: boolean = false;
  _ownersModel: ownersModel = new ownersModel();
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private crudservice: CrudServiceService
  ) {}

  ngOnInit(): void {
    this.fetchowner(parseInt(this.route.snapshot.paramMap.get('id')));
  }
  fetchowner(id: number) {
    this._ownersModel = new ownersModel();
    this.crudservice.getparticularowners(id).subscribe(
      (response: any) => {
        this._ownersModel = response;
      },
      (error) => {
        alert('Something went wrong!!');
      }
    );
  }
  viewlist(){
    this.router.navigate(['/owners']);
  }
  editOwner() {
    this.submitted = false;

    this.crudservice.updateowner(this._ownersModel).subscribe(
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
