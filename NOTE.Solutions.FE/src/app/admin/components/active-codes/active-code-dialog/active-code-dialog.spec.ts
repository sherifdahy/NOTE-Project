import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveCodeDialog } from './active-code-dialog';

describe('ActiveCodeDialog', () => {
  let component: ActiveCodeDialog;
  let fixture: ComponentFixture<ActiveCodeDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ActiveCodeDialog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActiveCodeDialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
