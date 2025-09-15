import { Component, OnInit } from '@angular/core';
import { ActiveCodeService } from '../../../../core/services/active-code.service';
import { ActiveCodeResponse } from '../../../../core/models/active-code/response/active-code-response';
import { NotificationService } from '../../../../core/services/notification.service';
import { MatDialog } from '@angular/material/dialog';
import { ActiveCodeDialog } from '../active-code-dialog/active-code-dialog';

@Component({
  selector: 'app-active-codes',
  standalone: false,
  templateUrl: './active-codes.component.html',
  styleUrls: ['./active-codes.component.css']
})
export class ActiveCodesComponent implements OnInit {

  activeCodes!: ActiveCodeResponse[];

  constructor(
    private dialog : MatDialog,
    private notificationService: NotificationService,
    private activeCodeService: ActiveCodeService) { }

  ngOnInit() {
    this.loadActiveCodes();
  }


  private loadActiveCodes() {
    this.activeCodeService.getAll().subscribe({
      next: (response: ActiveCodeResponse[]) => {
        this.activeCodes = response;
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    });
  }
  handleAddClick() {
    this.dialog.open(ActiveCodeDialog)
  }
  handleDeleteButton(id: number) {
    this.activeCodeService.delete(id).subscribe({
      next: () => {
        this.loadActiveCodes();
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    })
  }

}
