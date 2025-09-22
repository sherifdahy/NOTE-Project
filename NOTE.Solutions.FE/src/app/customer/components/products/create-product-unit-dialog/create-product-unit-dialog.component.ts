import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { UnitService } from '../../../../core/services/unit.service';
import { UnitResponse } from '../../../../core/models/unit/responses/unit-response';
import { NotificationService } from '../../../../core/services/notification.service';

@Component({
  selector: 'app-create-product-unit-dialog',
  standalone : false,
  templateUrl: './create-product-unit-dialog.component.html',
  styleUrls: ['./create-product-unit-dialog.component.css']
})
export class CreateProductUnitDialogComponent implements OnInit {

  units! : UnitResponse[];
  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private notificationService : NotificationService,
    private unitService : UnitService,
    private dialogRef: MatDialogRef<CreateProductUnitDialogComponent>
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.loadUnits();
  }

  private loadUnits(){
    this.unitService.getAll().subscribe({
      next :(response)=>{
        this.units = response;
      },
      error:(errors)=>{
        this.notificationService.showError(errors);
      }
    })
  }

  private initForm(): void {
    this.form = this.fb.group({
      internalCode: ['', Validators.required],
      globalCode: ['', Validators.required],
      globalCodeType: [0, Validators.required],   // القيمة الافتراضية "غير محدد"
      unitPrice: [0, [Validators.required, Validators.min(0.01)]],
      unitId: [0, Validators.required],
      description: ['', [Validators.required, Validators.minLength(5)]],
    });
  }

  handleSubmitClick() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.dialogRef.close(this.form);
  }

  handleCancelClick(): void {
    this.dialogRef.close(null); // لو المستخدم لغى
  }
}
