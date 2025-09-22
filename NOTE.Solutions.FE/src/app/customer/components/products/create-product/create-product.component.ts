import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { CreateProductUnitDialogComponent } from '../create-product-unit-dialog/create-product-unit-dialog.component';
import { NotificationService } from '../../../../core/services/notification.service';
import { ProductService } from '../../../../core/services/product.service';
import { ProductRequest } from '../../../../core/models/product/requests/product-request';
import { BranchService } from '../../../../core/services/branch.service';
import { BranchResponse } from '../../../../core/models/branch/responses/branch-response';
import { ProductVm } from '../../../../core/view-models/product/product-vm';
import { MapperService } from '../../../../core/services/mapper.service';

@Component({
  selector: 'app-create-product',
  standalone: false,
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {
  branches! : BranchResponse[];
  form!: FormGroup;
  constructor(
    private mapperService : MapperService,
    private branchService : BranchService,
    private fb: FormBuilder,
    private dialog: MatDialog,
    private notificationService: NotificationService,
    private productService : ProductService,
  ) {
    this.form = fb.group({
      name: fb.control('', [Validators.required]),
      branchId : fb.control(0,[Validators.required]),
      productUnits: fb.array([],[Validators.minLength(1)]),
    })
  }


  get name() {
    return this.form.get('name');
  }

  get branchId(){
    return this.form.get('branchId');
  }

  get productUnits(): FormArray {
    return this.form.get('productUnits') as FormArray;
  }


  ngOnInit() {
    this.loadBranches();
  }

  private loadBranches(){
    this.branchService.getAll().subscribe({
      next:(response)=>{
        this.branches = response;
      },
      error:(errors)=>{
        this.notificationService.showError(errors);
      }
    })
  }

  handleSubmitForm(){
    if(!this.form.valid)
    {
      this.form.markAllAsTouched();
      return;
    }


    let product = this.form.value as ProductVm;

    let productRequest : ProductRequest = this.mapperService.productMapper.toModel(product);

    this.productService.create(this.branchId?.value,productRequest).subscribe({
      next:(response)=>{
        this.form.reset();
      },
      error:(errors)=>{
        this.notificationService.showError(errors);
      }
    });
  }

  openCreateProductUnitDialog() {
    this.dialog.open(CreateProductUnitDialogComponent).afterClosed().subscribe((result) => {
      if (result) {
        this.productUnits.push(result);
        this.notificationService.showSuccess('تمت اضافة الوحدة بنجاح.');
      }
    }
    );
  }

  handleDeleteProductUnit(i : number){
    let productUnit = this.productUnits.controls[i];

    if(productUnit)
      this.productUnits.controls = this.productUnits.controls.filter((productUnit,index)=> index != i);
  }

}
