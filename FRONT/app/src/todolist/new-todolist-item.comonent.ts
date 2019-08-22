import { Component } from '@angular/core';
import { TodoListRepository } from './todolist-repository';

@Component({
    selector: 'new-todolist-item',
    templateUrl: 'new-todolist-item.component.html',
    providers: [ TodoListRepository ]
})

export class NewTodoListItemComponent {
    newDescription: string;

    constructor(private repository: TodoListRepository) { }

    async createNewItem(value: string) {
        await this.repository.createNew(value);
        this.newDescription = "";
    }
}