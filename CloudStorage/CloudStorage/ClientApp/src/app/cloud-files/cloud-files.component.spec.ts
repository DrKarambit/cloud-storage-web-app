import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CloudFilesComponent } from './cloud-files.component';

describe('CloudFilesComponent', () => {
  let component: CloudFilesComponent;
  let fixture: ComponentFixture<CloudFilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CloudFilesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CloudFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
