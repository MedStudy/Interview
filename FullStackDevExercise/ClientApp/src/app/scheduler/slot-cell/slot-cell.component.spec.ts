import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SlotCellComponent } from './slot-cell.component';

describe('SlotCellComponent', () => {
  let component: SlotCellComponent;
  let fixture: ComponentFixture<SlotCellComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SlotCellComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SlotCellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
