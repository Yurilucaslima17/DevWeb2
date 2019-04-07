import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageBackComponent } from './image-back.component';

describe('ImageBackComponent', () => {
  let component: ImageBackComponent;
  let fixture: ComponentFixture<ImageBackComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImageBackComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImageBackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
