import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { Permission } from '../../authentication/enums/permissions.enum';
import { PermissionService } from '../../authentication/services/permission.service';

@Directive({
  selector: '[hasPermission]',
  standalone: true,
})
export class HasPermissionDirective {
  constructor(
    private template: TemplateRef<any>,
    private view: ViewContainerRef,
    private perm: PermissionService
  ) { }

  @Input() set hasPermission(permission: Permission) {
    if (this.perm.can(permission)) {
      this.view.createEmbeddedView(this.template);
    } else {
      this.view.clear();
    }
  }
}
