import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { TodoListComponent } from './todolist.component';
import { By } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { TodoListItemComponent } from './todolist-item.component';

let httpClientSpy: { get: jasmine.Spy };

describe('TodoListComponent', () => {
  beforeEach(async(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        TodoListComponent,
        TodoListItemComponent
      ],
      providers: [
        { provide: HttpClient, use: httpClientSpy }
      ]
    }).compileComponents();
  }));

  it('exists', () => {
    const fixture = TestBed.createComponent(TodoListComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it('displays items to do', () => {
      const fixture = TestBed.createComponent(TodoListComponent);
      var element = fixture.debugElement.query(By.css('.todo-list'));
      expect(element).toBeTruthy();
  })
});