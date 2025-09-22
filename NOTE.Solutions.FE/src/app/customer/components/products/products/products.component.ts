import { Component, ElementRef, OnInit } from '@angular/core';
import { ProductResponse } from '../../../../core/models/product/responses/product-response';
import { NotificationService } from '../../../../core/services/notification.service';
import { ProductService } from '../../../../core/services/product.service';
import { BranchResponse } from '../../../../core/models/branch/responses/branch-response';
import { BranchService } from '../../../../core/services/branch.service';

@Component({
  selector: 'app-products',
  standalone: false,
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  selectedBranchId!:number;

  branches!: BranchResponse[];
  products!: ProductResponse[];

  constructor(
    private notificationService: NotificationService,
    private productService: ProductService,
    private branchService: BranchService,
  ) { }

  ngOnInit() {
    this.loadBranches();
    this.loadProducts();
  }

  private loadBranches() {
    this.branchService.getAll().subscribe({
      next: (response) => {
        this.branches = response;
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    });
  }

  loadProducts() {
    if (this.selectedBranchId) {
      this.productService.getAll(this.selectedBranchId).subscribe({
        next: (response: ProductResponse[]) => {
          this.products = response;
        },
        error: (errors) => {
          this.notificationService.showError(errors);
        }
      });
    }
  }
  handleAddClick() {

  }

  handleEditClick(id: number) {
  }

  handleDeleteClick(id: number) {
    this.productService.delete(id).subscribe({
      next: () => {
        this.loadProducts();
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    })
  }
}
