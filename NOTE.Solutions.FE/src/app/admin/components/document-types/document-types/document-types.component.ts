import { Component, OnInit } from '@angular/core';
import { DocumentTypeResponse } from '../../../../core/models/document-type/responses/document-type-response';
import { MatDialog } from '@angular/material/dialog';
import { NotificationService } from '../../../../core/services/notification.service';
import { DocumentTypeService } from '../../../../core/services/document-type.service';
import { CreateDocumentTypeDialogComponent } from '../create-document-type-dialog/create-document-type-dialog.component';
import { EditDocumentTypeDialogComponent } from '../edit-document-type-dialog/edit-document-type-dialog.component';

@Component({
  selector: 'app-document-types',
  standalone : false,
  templateUrl: './document-types.component.html',
  styleUrls: ['./document-types.component.css']
})
export class DocumentTypesComponent implements OnInit {

  documentTypes!: DocumentTypeResponse[];

  constructor(
    private dialog: MatDialog,
    private notificationService: NotificationService,
    private documentTypeService: DocumentTypeService) { }

  ngOnInit() {
    this.loadDocumentTypes();
  }


  private loadDocumentTypes() {
    this.documentTypeService.getAll().subscribe({
      next: (response: DocumentTypeResponse[]) => {
        this.documentTypes = response;
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    });
  }
  handleAddClick() {
    this.dialog.open(CreateDocumentTypeDialogComponent).afterClosed().subscribe(result => {
      if (result)
        this.loadDocumentTypes();
    });

  }

  handleEditClick(id : number) {
    this.dialog.open(EditDocumentTypeDialogComponent,{
      data: this.documentTypes.find(x=>x.id === id)
    });
  }

  handleDeleteClick(id: number) {
    this.documentTypeService.delete(id).subscribe({
      next: () => {
        this.loadDocumentTypes();
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    })
  }

}
