import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { Owner } from 'src/app/entities/owner.entity';
import { OwnerService } from 'src/app/services/owner.service';
import { AddOwnerComponent } from '../add-owner/add-owner.component';
import { Pet } from 'src/app/entities/pet.entity';
import { PetService } from 'src/app/services/pet.service';
import { PetUpdateCardComponent } from '../pet-update/pet-update-card.component';
import { AddPetComponent } from '../add-pet/add-pet.component';

@Component({
  selector: 'app-pet',
	templateUrl: 'pet.component.html'
})

export class PetComponent implements OnInit {
  pets: Pet[]= [];
  ownerFlag: boolean = false;
  ownerDrpdown: number;
  owners: Owner[]= [];
	displayedColumns: string[] = ['id', 'owner_Id', 'name', 'type', 'age', 'update', 'delete'];
  dataSource: MatTableDataSource<any>;

	constructor(
    private petService: PetService,
    private ownerService: OwnerService,
    private router: Router,
    public dialog: MatDialog
	) { }

	async ngOnInit() {
    this.owners = await this.ownerService.getAllOwners();
    this.pets = await this.petService.getAllPets();
    this.dataSource = new MatTableDataSource<any>(this.pets);

  }

  async onOwnerChange(event: any){
    this.ownerDrpdown = event.value;
    this.pets = (await this.petService.getAllPets()).filter(x => x.owner_Id == this.ownerDrpdown);
    // console.log(this.items);
    this.dataSource = new MatTableDataSource<any>(this.pets);
    if(!!this.ownerDrpdown){
      this.ownerFlag = true;
    }
    else{
      this.ownerFlag = false;
    }
  }
  
  async updatePet(id: number){
    // add update card here
    var pet = await this.petService.getPetById(id);
    const dialogRef = this.dialog.open(PetUpdateCardComponent, {
      width: '450px',
      height: '350px',
      data: {id: pet.id, owner_Id: pet.owner_Id, type: pet.type, name: pet.name, age: pet.age }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(!!result){
        this.petService.updatePet(result.id, result);
        let index = this.pets.findIndex(x => x.id == result.id);
        this.pets[index] = result;
        this.pets = this.pets.filter(x => x.owner_Id == this.ownerDrpdown);
        this.dataSource = new MatTableDataSource<any>(this.pets);
      }
      
    });
  }

  async addPet(){
    // add card here
    const dialogRef = this.dialog.open(AddPetComponent, {
      width: '400px',
      height: '350px'
    });

    dialogRef.afterClosed().subscribe(async result => {
        console.log('The dialog was closed');
        if(!!result){
          this.pets = (await this.petService.getAllPets()).filter(x => x.owner_Id == this.ownerDrpdown);
          this.dataSource = new MatTableDataSource<any>(this.pets);
        }
      
    });
  }

  async deletePet(id: number){
    // delete pet here
    this.petService.deletePet(id);
    this.pets = (await this.petService.getAllPets()).filter(x => x.owner_Id == this.ownerDrpdown);
    this.dataSource = new MatTableDataSource<any>(this.pets);
  }

  applyFilter(value: any){
    console.log(typeof(value));
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
}