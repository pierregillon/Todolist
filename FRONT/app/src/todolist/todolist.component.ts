import { Component, OnInit } from '@angular/core';
import { TodoListItem, TodoListRepository } from './todolist-repository';

@Component({
    selector: 'todolist',
    templateUrl: 'todolist.component.html',
    providers: [ TodoListRepository ]
})

export class TodoListComponent implements OnInit {
    items:TodoListItem[]

    constructor(private repository: TodoListRepository) { }

    async ngOnInit() {
        await this.reload();
    }

    async reload() {
        this.items = await this.repository.getAll();
    }
}