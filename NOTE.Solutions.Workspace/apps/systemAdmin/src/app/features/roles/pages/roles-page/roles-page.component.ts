import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService, RoleService } from '@app/shared/data-access';
import { RoleResponse } from '@app/shared/models';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-roles-page',
  standalone: false,
  templateUrl: './roles-page.component.html',
  styleUrls: ['./roles-page.component.css']
})
export class RolesPageComponent {

  roles$!: Observable<RoleResponse[]>;
  includeDisabled: boolean = false;
  constructor(
    private roleService: RoleService
  ) { }

  ngOnInit() {
    this.loadGrid();
  }

  loadGrid() {
    this.roles$ = this.roleService.getAll(this.includeDisabled);
  }
}
