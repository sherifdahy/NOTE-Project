import { Component, OnInit } from '@angular/core';
import { PermissionService } from '../../../../core/services/permission.service';
import { NotificationService } from '../../../../core/services/notification.service';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RoleService } from '../../../../core/services/role.service';
import { RoleRequest } from '../../../../core/models/role/requests/role-request';

@Component({
  selector: 'app-new-role',
  standalone: false,
  templateUrl: './new-role.component.html',
  styleUrls: ['./new-role.component.css']
})
export class NewRoleComponent implements OnInit {

  permissionsData!: string[];
  form!: FormGroup;
  constructor(private fb: FormBuilder, private notificationService: NotificationService,private roleService : RoleService, private permissionService: PermissionService) {
    this.form = this.fb.group({
      name: this.fb.control('', Validators.required),
      permissions: this.fb.array(
        [this.fb.control(0,[Validators.required,Validators.min(1)])],
        [Validators.required, Validators.minLength(1)]
      )
    });
  }

  get permissions(): FormArray {
    return this.form.get('permissions') as FormArray;
  }

  ngOnInit() {
    this.loadPermissions();
  }

  handleSubmitForm(){
    if(!this.form.valid)
    {
      this.form.markAllAsTouched();
      return;
    }

    var roleRequest = this.form.value as RoleRequest;

    this.roleService.create(roleRequest).subscribe({
      next : ()=>{
        this.notificationService.showSuccess('done');
      },
      error:(errors)=>{
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
}
