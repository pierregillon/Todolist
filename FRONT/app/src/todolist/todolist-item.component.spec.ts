import { TodoListItemComponent } from './todolist-item.component';
import { TodoListItem, TodoListRepository } from './todolist-repository';

describe('TodoListItemComponent', () => {
    let component:TodoListItemComponent;
    let repository: { edit: jasmine.Spy, remove: jasmine.Spy };

    beforeEach(()=> {
        repository = jasmine.createSpyObj('TodoListRepository', ['edit', 'remove']);
        component = new TodoListItemComponent(<any>repository)
    });

    it('initialize new description to current one', () => {
        // Arrange
        let item:TodoListItem = { id: "test", description: "call my dad", isDone: false };
        
        // Act
        component.item = item;

        // Assert
        expect(component.newDescription).toEqual("call my dad");
    });

    it('reset new description when edition cancelled', () => {
        // Arrange
        let item:TodoListItem = { id: "test", description: "call my dad", isDone: false };
        component.item = item;
        component.edit();

        // Act
        component.newDescription = "toto";
        component.cancelEdit();

        // Assert
        expect(component.newDescription).toEqual("call my dad");
    });

    it('cannot edit things done', () => {
        // Arrange
        let item:TodoListItem = { id: "test", description: "call my dad", isDone: true };
        component.item = item;

        // Act
        component.edit();

        // Assert
        expect(component.editing).toBeFalsy();
    });

    it('call web api when validating edition', () => {
        // Arrange
        component.item = { id: "123", description: "call my dad", isDone: false };
        component.edit();
        
        // Act
        component.newDescription = "call mum !";
        component.endEdit();

        // Assert
        expect(repository.edit.calls.count()).toBe(1, 'one call');
        expect(repository.edit).toHaveBeenCalledWith("123", "call mum !");
    });

    it('call web api when removing thing', () => {
        // Arrange
        component.item = { id: "123", description: "call my dad", isDone: false };
        
        // Act
        component.done();

        // Assert
        expect(repository.remove.calls.count()).toBe(1, 'one call');
        expect(repository.remove).toHaveBeenCalledWith("123");
    });
});