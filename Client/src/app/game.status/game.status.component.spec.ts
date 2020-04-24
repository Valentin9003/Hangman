import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Game.StatusComponent } from './game.status.component';

describe('Game.StatusComponent', () => {
  let component: Game.StatusComponent;
  let fixture: ComponentFixture<Game.StatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Game.StatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Game.StatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
