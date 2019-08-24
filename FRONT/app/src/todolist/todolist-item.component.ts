import { Component, Input, ViewChildren } from '@angular/core';
import { TodoListItem, TodoListRepository } from './todolist-repository';

@Component({
    selector: 'todolist-item',
    templateUrl: 'todolist-item.component.html',
    styleUrls: [ './todolist-item.component.less' ],
    providers: [ TodoListRepository ]
})

export class TodoListItemComponent {
    editing: boolean = false;
    newDescription: string;

    @ViewChildren('editInput') editInput;

    private _item: TodoListItem;

    @Input()
    set item(item: TodoListItem) {
        this._item = item;
        if (item != null) {
            this.newDescription = item.description;
        }
    }
    get item(): TodoListItem { return this._item; }

    constructor(private repository: TodoListRepository) { }

    edit() {
        this.editing = true;
        if (this.editInput) {
            setTimeout(() => {
                this.editInput.first.nativeElement.focus();
            });
        }
    }

    async endEdit() {
        await this.repository.edit(this.item.id, this.newDescription);
        this.item.description = this.newDescription;
        this.editing = false;
    }

    cancelEdit() {
        this.newDescription = this.item.description;
        this.editing = false;
    }

    async done() {
        await this.repository.remove(this.item.id);
        this.item.isDone = true;
    }
}