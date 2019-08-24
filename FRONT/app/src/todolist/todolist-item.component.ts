import { Component, Input } from '@angular/core';
import { TodoListItem } from './todolist-repository';

@Component({
    selector: 'todolist-item',
    templateUrl: 'todolist-item.component.html'
})

export class TodoListItemComponent {
    @Input() item:TodoListItem;
}