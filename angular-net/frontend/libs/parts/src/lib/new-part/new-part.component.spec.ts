import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NewPartComponent } from './new-part.component';

describe('NewPartComponent', () => {
  let component: NewPartComponent;
  let fixture: ComponentFixture<NewPartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewPartComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NewPartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
