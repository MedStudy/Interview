import { Component, Input, OnInit } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { MatTableDataSource } from '@angular/material/table';
import {MatDialog} from '@angular/material/dialog';
import { Pet } from 'src/app/shared-services/models/pet';
import  { PetsService } from '../../services/pets.service'
import {DeleteDialogComponent} from '../../../shared-services/components/delete-dialog/delete-dialog.component';

@Component({
  selector: 'pet-home',
  templateUrl: './pet-home.component.html',
  styleUrls: ['./pet-home.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})

export class PetHomeComponent implements OnInit {

  @Input() petList: Pet[];

  petDataSource : MatTableDataSource<Pet>;
  pets : Promise<Pet[]>;
  petColumns = ['Name','Age','Type', 'Actions'];
  constructor(private petService : PetsService,public matDialog : MatDialog) { }
  expandedElement : string | null;

  ngOnInit(): void {
      this.petDataSource = new MatTableDataSource(this.petList);
   }

   getAllpets(){
      this.pets =  this.petService.getAllPets().toPromise();
      this.pets.then( data => {
        this.petDataSource = new MatTableDataSource(data);
      } );
   }

   create(newpet : Pet){
      this.petService.createPet(newpet).toPromise().then(x=>console.log(x));
   }

   edit(data){
     console.log(data);
   }

   delete(data: Pet){
     const confirmDialog = this.matDialog.open(DeleteDialogComponent);
     confirmDialog.afterClosed().subscribe(result => {
        if(result == true){
          this.petService.deletePet(data.id).toPromise().then(x=>this.getAllpets());
        }
     });

     
   }

}
