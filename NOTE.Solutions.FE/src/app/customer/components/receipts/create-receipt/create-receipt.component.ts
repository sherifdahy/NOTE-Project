import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReceiptService } from '../../../../core/services/receipt.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { BranchService } from '../../../../core/services/branch.service';
import { BranchResponse } from '../../../../core/models/branch/responses/branch-response';
import { ActiveCodeService } from '../../../../core/services/active-code.service';
import { ActiveCodeResponse } from '../../../../core/models/active-code/response/active-code-response';
import { MatDialog } from '@angular/material/dialog';
import { AddDocumentDetailDialogComponent } from '../add-document-detail-dialog/add-document-detail-dialog.component';
import { PosResponse } from '../../../../core/models/pos/responses/pos-response';
import { PosService } from '../../../../core/services/pos.service';
import { MapperService } from '../../../../core/services/mapper.service';
import { DocumentTypeResponse } from '../../../../core/models/document-type/responses/document-type-response';
import { DocumentTypeService } from '../../../../core/services/document-type.service';
import { ReceiptVm } from '../../../../core/view-models/receipt/receipt-vm';

@Component({
  selector: 'app-create-receipt',
  standalone: false,
  templateUrl: './create-receipt.component.html',
  styleUrls: ['./create-receipt.component.css']
})
export class CreateReceiptComponent implements OnInit {
  documentTypes!: DocumentTypeResponse[];
  branches!: BranchResponse[];
  poss!: PosResponse[];
  activeCodes!: ActiveCodeResponse[];
  form!: FormGroup;
  constructor(
    private dialog: MatDialog,
    private fb: FormBuilder,
    private posService: PosService,
    private documentTypeService: DocumentTypeService,
    private mapperService: MapperService,
    private branchService: BranchService,
    private activeCodeService: ActiveCodeService,
    private receiptService: ReceiptService,
    private notificationService: NotificationService) {
    this.form = this.fb.group({
      header: this.fb.group({
        dateTime: this.fb.control(new Date(Date.now() - new Date().getTimezoneOffset() * 60000).toISOString().slice(0, 16), [Validators.required]),
        documentNumber: this.fb.control('', [Validators.required]),
      }),
      buyer: this.fb.group({
        name: this.fb.control('', [Validators.required]),
        ssn: this.fb.control('', [Validators.required]),
        type: this.fb.control(0, [Validators.required, Validators.min(1)]),
      }),
      branchId: this.fb.control(0, [Validators.required, Validators.min(1)]),
      posId: this.fb.control(0, [Validators.required, Validators.min(1)]),
      paymentMethod: this.fb.control(0, [Validators.required, Validators.min(1)]),
      activeCodeId: this.fb.control(0, [Validators.required, Validators.min(1)]),
      documentDetails: this.fb.array([], [Validators.required, Validators.minLength(1)]),
      documentTypeId: this.fb.control(0, [Validators.required, Validators.min(1)]),
    });
  }
  get documentDetails() {
    return this.form.get('documentDetails') as FormArray;
  }
  ngOnInit() {
    this.loadBranches();
    this.loadActiveCodes();
    this.loadDocumentTypes();
    this.addListenerToBranchId();
  }

  addListenerToBranchId() {
    this.form.get('branchId')?.valueChanges.subscribe(branchId => {
      if (branchId && branchId > 0) {
        this.receiptService.getNextNumber(branchId).subscribe({
          next: (response) => {
            this.form.get('header')?.get('documentNumber')?.setValue(`${response}`);
          },
          error: (err) => {
            this.notificationService.showError(err);
          }
        });
      } else {
        this.form.get('header')?.get('documentNumber')?.setValue('0');
      }
    });
  }

  loadDocumentTypes() {
    this.documentTypeService.getAll().subscribe(response => {
      this.documentTypes = response;
    });
  }

  addDocumentDetail() {
    if (this.form.get('branchId')?.invalid || this.form.get('branchId')?.value === 0) {
      let errors: Record<string, string[]> = { 'BranchId': ['يجب اختيار الفرع اولا'] };
      this.notificationService.showError(errors);
      return;
    }
    this.dialog.open(AddDocumentDetailDialogComponent, {
      data: { branchId: this.form.get('branchId')?.value }
    }).afterClosed().subscribe((result) => {
      if (result) {
        this.documentDetails.push(this.fb.group(result));
      }
    }
    )
  }
  loadActiveCodes() {
    this.activeCodeService.getAll().subscribe({
      next: (response) => {
        this.activeCodes = response;
      },
      error: (err) => {
        this.notificationService.showError(err);
      }
    });
  }
  loadBranches() {
    this.branchService.getAll().subscribe({
      next: (response) => {
        this.branches = response;
      },
      error: (err) => {
        this.notificationService.showError(err);
      }
    });
  }
  removeDocumentDetail(i: number) {
    this.documentDetails.removeAt(i);
  }
  handleChangeBranch() {
    this.poss = [];
    this.posService.getAll(this.form.get('branchId')?.value).subscribe({
      next: (response) => {
        this.poss = response;
      },
      error: (err) => {
        this.notificationService.showError(err);
      }
    });
  }
  handleSubmitForm() {
    if (!this.form.valid) {
      this.form.markAllAsTouched();
      return;
    }

    let receiptVm = this.form.value as ReceiptVm;

    this.receiptService.create(this.form.get('branchId')?.value, this.mapperService.receiptMapper.toModel(receiptVm)).subscribe({
      next: (response) => {
        this.notificationService.showSuccess("تم انشاء السند بنجاح");
        this.form.reset();
        this.documentDetails.clear();
        this.form.get('header')?.get('dateTime')?.setValue(new Date(Date.now() - new Date().getTimezoneOffset() * 60000).toISOString().slice(0, 16));

      },
      error: (err) => {
        this.notificationService.showError(err);
      }
    });
  }
}
