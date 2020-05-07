import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameStatusComponent } from './game.status.component';

describe('Game.StatusComponent', () => {
  let component: GameStatusComponent;
  let fixture: ComponentFixture<GameStatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameStatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
