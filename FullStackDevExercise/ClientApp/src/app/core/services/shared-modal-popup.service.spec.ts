import { TestBed } from '@angular/core/testing';

import { SharedModalPopupService } from './shared-modal-popup.service';

describe('SharedModalPopupService', () => {
  let service: SharedModalPopupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SharedModalPopupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
