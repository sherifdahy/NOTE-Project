import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NotificationService, RoleService } from '@app/shared/data-access';
import { RoleResponse } from '@app/shared/models';

@Component({
  selector: 'app-role-card',
  standalone: false,
  templateUrl: './role-card.component.html',
  styleUrls: ['./role-card.component.css']
})
export class RoleCardComponent implements OnInit {

  @Input() role!: RoleResponse;
  @Output() roleToggleStatusListner = new EventEmitter<void>();

  constructor(
    private notificationService: NotificationService,
    private roleService: RoleService) { }

  ngOnInit() {
  }

  toggleStatus(id: number) {
    this.roleService.toggleStatus(id).subscribe({
      next: () => {
        this.roleToggleStatusListner.emit();
      },
      error: (errors) => {
        this.notificationService.handleError(errors)
      }
    })
  }

}
