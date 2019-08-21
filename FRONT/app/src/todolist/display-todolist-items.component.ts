import { Component, OnInit } from '@angular/core';
import { TodoListRepository, TodoListItem } from './todolist-repository';

@Component({
    selector: 'display-todolist-items',
    templateUrl: 'display-todolist-items.component.html',
    providers: [ TodoListRepository ]
})

export class DisplayTodoListItemsComponent implements OnInit {
    items:TodoListItem[]

    constructor(private repository: TodoListRepository) { }

    async ngOnInit() { 
        this.items = await this.repository.getAll();
    }
}