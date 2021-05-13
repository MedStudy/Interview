import { Component, OnInit } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { MatTableDataSource } from '@angular/material/table';
import {MatDialog} from '@angular/material/dialog';
import { Owner } from 'src/app/shared-services/models/owner';
import  { OwnersService } from '../../services/owners.service'
import {DeleteDialogComponent} from '../../../shared-services/components/delete-dialog/delete-dialog.component';
import {OwnerDialogComponent} from '../dialog/owner-dialog/owner-dialog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})
export class HomeComponent implements OnInit {
  dataSource : MatTableDataSource<Owner>;
  owners : Promise<Owner[]>;
  displayedColumns = ['collapse','firstName','lastName','Actions'];
  constructor(private ownerService : OwnersService,
              public matDialog : MatDialog) { }
  expandedElement : string | null;
  ngOnInit(): void {
      this.getAllOwners();
   }

   getAllOwners(){
      this.owners =  this.ownerService.getOwners().toPromise();
      this.owners.then( data => {
        this.dataSource = new MatTableDataSource(data);
      } );
   }

   createOwner(){
      var newOwner = new Owner();
      const createDialog = this.matDialog.open(OwnerDialogComponent,{
        data:{owner:newOwner,action:'Create'}
      });
      createDialog.afterClosed().subscribe(result => {
        if(result == true) this.getAllOwners();
     });
   }

   edit(data){
      const createDialog = this.matDialog.open(OwnerDialogComponent,{
        data:{owner:data,action:'Edit'}
      });
      createDialog.afterClosed().subscribe(result => {
           if(result == true) this.getAllOwners();
     });
   }

   delete(data: Owner){
     const confirmDialog = this.matDialog.open(DeleteDialogComponent);
     confirmDialog.afterClosed().subscribe(result => {
        if(result == true){
          this.ownerService.deleteOwner(data.id).toPromise().then(x=>this.getAllOwners());
        }
     });

     
   }

}
