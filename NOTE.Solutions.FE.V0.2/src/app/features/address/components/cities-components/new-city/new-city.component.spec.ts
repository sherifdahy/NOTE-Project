/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NewCityComponent } from './new-city.component';

describe('NewCityComponent', () => {
  let component: NewCityComponent;
  let fixture: ComponentFixture<NewCityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewCityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewCityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
