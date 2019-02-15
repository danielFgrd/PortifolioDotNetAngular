import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuMecanicoComponent } from './menu-mecanico.component';

describe('MenuMecanicoComponent', () => {
  let component: MenuMecanicoComponent;
  let fixture: ComponentFixture<MenuMecanicoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuMecanicoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuMecanicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
