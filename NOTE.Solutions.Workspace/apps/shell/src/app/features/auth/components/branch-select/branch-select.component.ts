import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BranchResponse, BranchService } from '@app/branches';
import { AccountService, NotificationService } from '@app/shared/data-access';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-branch-select',
  standalone: false,
  templateUrl: './branch-select.component.html',
  styleUrls: ['./branch-select.component.css']
})
export class BranchSelectComponent implements OnInit {
  branches$!: Observable<BranchResponse[]>;
  constructor(
    private branchService: BranchService,
    private notificationService: NotificationService,
    private router : Router,
    private accountService: AccountService) {
  }

  ngOnInit() {
    this.branches$ = this.accountService.getBranches();
  }

  onBranchChange(branchId: number) {
    if (branchId) {
      this.branchService.setCurrentBranch(branchId)
      this.router.navigateByUrl('client/dashboard');
    }
  }
}
