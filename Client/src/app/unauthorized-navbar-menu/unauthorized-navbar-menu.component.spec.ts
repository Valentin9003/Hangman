import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnauthorizedNavbarMenuComponent } from './unauthorized-navbar-menu.component';

describe('UnauthorizedNavbarMenuComponent', () => {
  let component: UnauthorizedNavbarMenuComponent;
  let fixture: ComponentFixture<UnauthorizedNavbarMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnauthorizedNavbarMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnauthorizedNavbarMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
