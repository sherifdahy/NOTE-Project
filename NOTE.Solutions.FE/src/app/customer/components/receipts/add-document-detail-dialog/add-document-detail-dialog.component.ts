import { Component, Inject, inject, OnInit } from '@angular/core';
import { ProductUnitService } from '../../../../core/services/product-unit.service';
import { ProductUnitResponse } from '../../../../core/models/product-unit/responses/product-unit-response';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificationService } from '../../../../core/services/notification.service';

@Component({
  selector: 'app-add-document-detail-dialog',
  standalone: false,
  templateUrl: './add-document-detail-dialog.component.html',
  styleUrls: ['./add-document-detail-dialog.component.css']
})
export class AddDocumentDetailDialogComponent implements OnInit {
  form!: FormGroup;
  productUnits!: ProductUnitResponse[];
  constructor(
    private fb: FormBuilder,
    private notificationService: NotificationService,
    @Inject(MAT_DIALOG_DATA) private data: { branchId: number },
    private productUnitService: ProductUnitService,
    private dialogRef: MatDialogRef<AddDocumentDetailDialogComponent>
  ) {

  }

  get productUnitId() {
    return this.form.get('productUnitId');
  }

  get quantity() {
    return this.form.get('quantity');
  }

  get unitPrice() {
    return this.form.get('unitPrice');
  }

  ngOnInit() {
    this.form = this.fb.group({
      productUnitId: this.fb.control(0, [Validators.required, Validators.min(1)]),
      quantity: this.fb.control(1, [Validators.required, Validators.min(1)]),
      unitPrice: this.fb.control(0, [Validators.required, Validators.min(0)]),
    });

    this.loadProductUnits();
  }

  handleSubmit() {
    this.dialogRef.close(this.form.value);
  }

  loadProductUnits() {
    this.productUnitService.getAll(this.data.branchId).subscribe({
      next: (response) => {
        this.productUnits = response;
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    });
  }

  handleChangeSelectedProductUnit(event: Event) {
    const value = (event.target as HTMLSelectElement).value;
    const selectedProductUnit = this.productUnits.find(x => x.id == Number(value));

    if (selectedProductUnit) {
      this.unitPrice?.setValue(selectedProductUnit.unitPrice);
    } else {
      this.unitPrice?.setValue(0);
    }
  }
  handleClose() {
    this.dialogRef.close();
  }

}
