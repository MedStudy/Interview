import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PetHomeComponent } from './home.component';

describe('PetHomeComponent', () => {
  let component: PetHomeComponent;
  let fixture: ComponentFixture<PetHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PetHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PetHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
