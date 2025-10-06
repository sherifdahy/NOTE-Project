import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from '../../../../core/services/notification.service';
import { RoleService } from '../../../../core/services/role.service';
import { PermissionService } from '../../../../core/services/permission.service';
import { RoleDetailResponse } from '../../../../core/models/role/responses/role-detail-response';
import { RoleRequest } from '../../../../core/models/role/requests/role-request';

@Component({
  selector: 'app-role-detail',
  standalone: false,
  templateUrl: './role-detail.component.html',
  styleUrls: ['./role-detail.component.css']
})
export class RoleDetailComponent implements OnInit {

  permissionsData!: string[];
  form!: FormGroup;
  id : number;
  constructor(private activatedRoute: ActivatedRoute, private fb: FormBuilder, private notificationService: NotificationService, private roleService: RoleService, private permissionService: PermissionService) {
    this.id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.form = this.fb.group({
      name: this.fb.control('', Validators.required),
      permissions: this.fb.array([])
    });
  }
  get permissions(): FormArray {
    return this.form.get('permissions') as FormArray;
  }

  ngOnInit() {
    this.loadPermissions();

    this.getRoleDetail(this.id);
  }
  handleSubmitForm() {
    if (!this.form.valid) {
      this.form.markAllAsTouched();
      return;
    }

    var roleRequest = this.form.value as RoleRequest;

    this.roleService.update(this.id,roleRequest).subscribe({
      next: () => {
        this.notificationService.showSuccess('done');
      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    });

  }
  loadPermissions() {
    this.permissionService.getAll().subscribe({
      next: (response) => {
        this.permissionsData = response;
      },
      error: (error) => {
        this.notificationService.showError(error);
      }
    })
  }

  handleAddNewPermission() {
    this.permissions.push(this.fb.control(''));
  }

  handleRemovePermission(index: number) {
    this.permissions.removeAt(index);
  }

  getRoleDetail(id: number) {
    this.roleService.get(id).subscribe({
      next: (response) => {
        this.form.get('name')?.setValue(response.name);

        this.permissions.clear();

        response.permissions.forEach(permission => {
          this.permissions.push(this.fb.control(permission));
        });

      },
      error: (errors) => {
        this.notificationService.showError(errors);
      }
    });
  }

}
