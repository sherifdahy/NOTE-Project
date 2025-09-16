import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActiveCodeService } from '../../../../core/services/active-code.service';
import { ActiveCodeRequest } from '../../../../core/models/active-code/request/active-code-request';
import { NotificationService } from '../../../../core/services/notification.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-active-code-dialog',
  standalone: false,
  templateUrl: './active-code-dialog.component.html',
  styleUrls: ['./active-code-dialog.component.css']
})
export class ActiveCodeDialogComponent {

  form! : FormGroup;

  constructor(

    private dialogRef : MatDialogRef<ActiveCodeDialogComponent>,
    private notificationService : NotificationService,
    fb:FormBuilder,
    private activecodeService : ActiveCodeService)
  {
    this.form = fb.group({
      code : fb.control('',[Validators.required,Validators.minLength(4)])
    });
  }

  get code (){
    return this.form.get('code');
  }

  handleCloseClick(){
    this.dialogRef.close(false);
  }

  handleSubmitForm()
  {
    if(!this.form.valid)
    {
      this.form.markAllAsTouched();
      return;
    }

    let activeCode = this.form.value as ActiveCodeRequest;

    this.activecodeService.create(activeCode).subscribe({
      next:()=>{
        this.dialogRef.close(true);
        this.notificationService.showSuccess('تمت اضافة الكود بنجاح');
      },
      error:(errors)=>{
        this.notificationService.showError(errors)
      }
    })
  }
}
