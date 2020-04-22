import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VictimPictureComponent } from './victim-picture.component';

describe('VictimPictureComponent', () => {
  let component: VictimPictureComponent;
  let fixture: ComponentFixture<VictimPictureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VictimPictureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VictimPictureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
