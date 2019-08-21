import { TodoListRepository, TodoListItem } from "./todolist-repository";
import { Observable } from 'rxjs';

let httpClientSpy: { get: jasmine.Spy };
let repository: TodoListRepository;

describe('TodoListRepository', () => {
    beforeEach(() => {
        httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
        repository = new TodoListRepository(<any> httpClientSpy);
    });
  
    it('query api to get todo list items', async () => {
        // Arrange
        const expectedHeroes: TodoListItem[] = [
            { id: 1, name: 'A' },
            { id: 2, name: 'B' }
        ];
        httpClientSpy.get.and.returnValue(asyncData(expectedHeroes));
        
        // Act
        let results = await repository.getAll();

        // Assert
        expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
        expect(results.length).toBe(2);
    });
  });

function asyncData(data) {
    return new Observable<TodoListItem[]>(observer => {
        observer.next(data);
        observer.complete();
    })
}