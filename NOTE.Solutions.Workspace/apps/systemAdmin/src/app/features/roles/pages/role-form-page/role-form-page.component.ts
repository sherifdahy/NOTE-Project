import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService, RoleService } from '@app/shared/data-access';
import { RoleDetailResponse } from '@app/shared/models';
import { PERMISSIONS, PermissionGroup } from '@app/shared/constants';
import { Observable, tap } from 'rxjs';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';

@Component({
  selector: 'app-role-form-page',
  standalone: false,
  templateUrl: './role-form-page.component.html',
  styleUrls: ['./role-form-page.component.css']
})
export class RoleFormPageComponent implements OnInit {

  role$!: Observable<RoleDetailResponse> | null;
  roleId!: number | null;
  permissions: PermissionGroup[] = PERMISSIONS;
  roleForm!: FormGroup;

  constructor(
    private notificationService: NotificationService,
    private route: ActivatedRoute,
    private roleService: RoleService,
    private router: Router,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    const idParam = this.route.snapshot.paramMap.get('id');
    this.roleId = idParam ? Number(idParam) : null;

    this.roleForm = this.fb.group({
      name: [''],
      permissions: this.fb.array([])
    });

    // build permissions once
    for (const group of this.permissions) {
      for (const perm of group.permissions) {
        this.permissionsArray.push(new FormControl(false));
      }
    }

    if (this.roleId) {
      this.roleService.get(this.roleId).subscribe(role => {
        this.patchForm(role);
      });
    }
  }


  private patchForm(role: RoleDetailResponse) {
    this.roleForm.get('name')?.setValue(role.name);

    let index = 0;
    for (const group of this.permissions) {
      for (const perm of group.permissions) {
        this.permissionsArray
          .at(index)
          .setValue(role.permissions.includes(perm.value));
        index++;
      }
    }
  }


  get permissionsArray(): FormArray {
    return this.roleForm.get('permissions') as FormArray;
  }

  get permissionsArrayControls(): FormControl[] {
    return this.permissionsArray.controls as FormControl[];
  }

  selectAllGroup(groupIndex: number, checked: boolean) {
    let startIndex = 0;
    for (let i = 0; i < groupIndex; i++) {
      startIndex += this.permissions[i].permissions.length;
    }
    const groupLength = this.permissions[groupIndex].permissions.length;
    for (let i = 0; i < groupLength; i++) {
      this.permissionsArray.at(startIndex + i).setValue(checked);
    }
  }

  selectAllGlobal(checked: boolean) {
    this.permissionsArray.controls.forEach(control => control.setValue(checked));
  }

  getGlobalIndex(groupIndex: number, permIndex: number): number {
    let startIndex = 0;
    for (let i = 0; i < groupIndex; i++) {
      startIndex += this.permissions[i].permissions.length;
    }
    return startIndex + permIndex;
  }

  saveRole() {
    const updatedPermissions: string[] = [];
    let index = 0;
    for (const group of this.permissions) {
      for (const perm of group.permissions) {
        if (this.permissionsArray.at(index).value) {
          updatedPermissions.push(perm.value);
        }
        index++;
      }
    }

    const roleData: RoleDetailResponse = {
      ...this.roleForm.value,
      permissions: updatedPermissions
    };

    if (this.roleId) {
      // Edit
      this.roleService.update(this.roleId, roleData).subscribe({
        next: () => this.router.navigate(['/system-admin/roles']),
        error: err => this.notificationService.handleError(err),
      });
    } else {
      // Create
      this.roleService.create(roleData).subscribe({
        next: () => this.router.navigate(['/system-admin/roles']),
        error: err => this.notificationService.handleError(err),
      });
    }
  }

}
