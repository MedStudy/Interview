import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Owner } from 'src/app/entities/owner.entity';
import { OwnerUpdateCardComponent } from '../owner-update-card/owner-update-card.component';
import { OwnerService } from 'src/app/services/owner.service';
import { AddOwnerComponent } from '../add-owner/add-owner.component';

@Component({
  selector: 'app-owner',
	templateUrl: 'owner.component.html'
})

export class OwnerComponent implements OnInit, AfterViewInit {
	owners: Owner[];
	displayedColumns: string[] = ['id', 'first_Name', 'last_Name', 'edit', 'remove'];
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

	constructor(
		private ownerService: OwnerService,
    private router: Router,
    public dialog: MatDialog
	) { }

	async ngOnInit() {
    this.owners = await this.ownerService.getAllOwners();
    this.dataSource = new MatTableDataSource<any>(this.owners);

  }

  ngAfterViewInit(){
    if(!!this.owners){
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    }
  }
  
  async updateOwner(id: any){
    // add update card here
    var owner = await this.ownerService.getOwnerById(id);
    const dialogRef = this.dialog.open(OwnerUpdateCardComponent, {
      width: '400px',
      height: '300px',
      data: {id: owner.id, first_Name: owner.first_Name, last_Name: owner.last_Name }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(!!result){
        this.ownerService.updateOwner(result.id, result);
        let index = this.owners.findIndex(x => x.id == result.id);
        this.owners[index] = result;
        this.dataSource = new MatTableDataSource<any>(this.owners);
        alert("Updated successfully.");
      }
      
    });
  }

  addOwner(){
    // add card here
    const dialogRef = this.dialog.open(AddOwnerComponent, {
      width: '400px',
      height: '350px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if(!!result){
        console.log('The dialog was closed');
        this.owners.push(result);
        this.dataSource = new MatTableDataSource<any>(this.owners);
        alert("Added successfully.");
      }
        
      
    });
  }

  async deleteOwner(id: number){
    // delete owner here
    this.ownerService.deleteOwner(id);
    let index = this.owners.findIndex(x => x.id == id);
    this.owners.splice(index, 1);
    this.dataSource = new MatTableDataSource<any>(this.owners);
    alert("Deleted Successfully.");
  }

  applyFilter(value: any){
    console.log(typeof(value));
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
}