import { Component, OnInit} from '@angular/core';
import { ReceiptService } from '../../../../core/services/receipt.service';
import { ReceiptResponse } from '../../../../core/models/receipt/responses/receipt-response';
import { BranchResponse } from '../../../../core/models/branch/responses/branch-response';
import { BranchService } from '../../../../core/services/branch.service';
import { NotificationService } from '../../../../core/services/notification.service';

@Component({
  selector: 'app-receipts',
  standalone: false,
  templateUrl: './receipts.component.html',
  styleUrls: ['./receipts.component.css']
})
export class ReceiptsComponent implements OnInit {
  selectedBranchId!: string ;
  branches!: BranchResponse[];
  receipts!: ReceiptResponse[];
  constructor(
    private notificationService: NotificationService,
    private branchService: BranchService,
    private receiptService: ReceiptService
  ) { }

  ngOnInit() {
    this.loadBranches();
  }

  loadBranches() {
    this.branchService.getAll().subscribe({
      next: (res) => {
        this.branches = res;
      },
      error: (err) => {
        this.notificationService.showError(err);
      }
    })
  }

  loadReceipts(branchId: string ) {
    this.receiptService.getAll(Number(branchId)).subscribe({
      next: (res) => {
        console.log(res);
        this.receipts = res;
      },
      error: (err) => {
        this.notificationService.showError(err);
      }
    })
  }


}
