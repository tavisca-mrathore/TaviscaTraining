import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdvertismentCardComponent } from './advertisment-card.component';

describe('AdvertismentCardComponent', () => {
  let component: AdvertismentCardComponent;
  let fixture: ComponentFixture<AdvertismentCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdvertismentCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdvertismentCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
