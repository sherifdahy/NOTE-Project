import { Component, OnInit } from '@angular/core';
import { RoleService } from '../../../../core/services/role.service';
import { RoleResponse } from '../../../../core/models/role/responses/role-response';
import { NotificationService } from '../../../../core/services/notification.service';

@Component({
  selector: 'app-roles',
  standalone: false,
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})

export class RolesComponent implements OnInit {
  showDeleted: boolean;
  roles!: RoleResponse[];
  constructor(private roleService: RoleService, private notificationService: NotificationService) {
    this.roles = [];
    this.showDeleted = false;
   }

  ngOnInit() {
    this.loadRoles();
  }

  loadRoles() {
    this.roleService.getAll(this.showDeleted).subscribe({
      next: (responseRoles) => {
        this.roles = responseRoles;
      },
      error: (error) => {
        this.notificationService.showError(error);
      }
    })
  }
  handleChangeDeletedFilter() {
    this.loadRoles();
  }


  toggleState(id : number){
    this.roleService.toggleState(id).subscribe({
      next :()=>{
        this.loadRoles();
        this.notificationService.showSuccess('تمت العمليه بنجاح');
      },
      error :(errors)=>{
        this.notificationService.showError(errors);
      }
    });
  }
}
