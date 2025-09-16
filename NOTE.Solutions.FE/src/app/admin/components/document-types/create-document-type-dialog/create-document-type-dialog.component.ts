import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { NotificationService } from '../../../../core/services/notification.service';
import { DocumentTypeService } from '../../../../core/services/document-type.service';
import { DocumentTypeRequest } from '../../../../core/models/document-type/requests/document-type-request';

@Component({
  selector: 'app-create-document-type-dialog',
  standalone : false,
  templateUrl: './create-document-type-dialog.component.html',
  styleUrls: ['./create-document-type-dialog.component.css']
})
export class CreateDocumentTypeDialogComponent {

  form!: FormGroup;

  constructor(

    private dialogRef: MatDialogRef<CreateDocumentTypeDialogComponent>,
    private notificationService: NotificationService,
    fb: FormBuilder,
    private documentTypeService: DocumentTypeService) {
    this.form = fb.group({
      type: fb.control('', [Validators.required, Validators.minLength(1)]),
      version: fb.control('', [Validators.required])
    });
  }


  get type() {
    return this.form.get('type');
  }
  get version() {
    return this.form.get('version');
  }

  handleCloseClick() {
    this.dialogRef.close(false);
  }

  handleSubmitForm() {
    if (!this.form.valid) {
      this.form.markAllAsTouched();
      return;
    }

    let documentType = this.form.value as DocumentTypeRequest;

    this.documentTypeService.create(documentType).subscribe({
      next: () => {
        this.dialogRef.close(true);
        this.notificationService.showSuccess('تمت اضافة نوع الوثيقة بنجاح');
      },
      error: (errors) => {
        this.notificationService.showError(errors)
      }
    })
  }
}
