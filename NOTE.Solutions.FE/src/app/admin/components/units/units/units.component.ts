import { Component, OnInit } from '@angular/core';
import { UnitResponse } from '../../../../core/models/unit/responses/unit-response';
import { MatDialog } from '@angular/material/dialog';
import { NotificationService } from '../../../../core/services/notification.service';
import { UnitService } from '../../../../core/services/unit.service';
import { CreateUnitDialogComponent } from '../create-unit-dialog/create-unit-dialog.component';
import { EditUnitDialogComponent } from '../edit-unit-dialog/edit-unit-dialog.component';

@Component({
  selector: 'app-units',
  standalone: false,
  templateUrl: './units.component.html',
  styleUrls: ['./units.component.css']
})
export class UnitsComponent  {

  units!: UnitResponse[];

  constructor(
    private dialog: MatDialog,
    private notificationService: NotificationService,
    private unitService: UnitService) { }

  ngOnInit() {
    this.loadUnits();
  }


  private loadUnits() {
    this.unitService.getAll().subscribe({
      next: (response: UnitResponse[]) => {
        this.units = response;
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    });
  }
  handleAddClick() {
    this.dialog.open(CreateUnitDialogComponent).afterClosed().subscribe(result => {
      if (result)
        this.loadUnits();
    });

  }

  handleEditClick(id: number) {
    this.dialog.open(EditUnitDialogComponent, {
      data: this.units.find(x => x.id === id)
    });
  }

  handleDeleteClick(id: number) {
    this.unitService.delete(id).subscribe({
      next: () => {
        this.loadUnits();
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    })
  }


}
