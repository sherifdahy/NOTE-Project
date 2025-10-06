import { Component, OnInit } from '@angular/core';
import { GovernorateService } from '../../../../../core/services/governorate.service';
import { NotificationService } from '../../../../../core/services/notification.service';
import { GovernorateResponse } from '../../../../../core/models/governorate/responses/governorate-response';

@Component({
  selector: 'app-governorates',
  standalone : false,
  templateUrl: './governorates.component.html',
  styleUrls: ['./governorates.component.css']
})
export class GovernoratesComponent implements OnInit {
  governorates!: GovernorateResponse[];

  constructor(private governorateService: GovernorateService, private notificationService: NotificationService) {
    this.governorates = [];
  }

  ngOnInit() {
    this.loadGovernorates();
  }

  loadGovernorates() {
    this.governorateService.getAll().subscribe({
      next: (response: GovernorateResponse[]) => this.governorates = response,
      error: (err: any) => this.notificationService.showError(err)
    })
  }

}
