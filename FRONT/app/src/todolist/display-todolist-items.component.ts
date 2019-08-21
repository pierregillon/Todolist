import { Component, OnInit } from '@angular/core';
import { TodoListRepository } from './todolist-repository';

@Component({
    selector: 'display-todolist-items',
    templateUrl: 'display-todolist-items.component.html',
    providers: [ TodoListRepository ]
})

export class DisplayTodoListItemsComponent implements OnInit {
    constructor() { }

    ngOnInit() { }
}