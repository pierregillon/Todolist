import { NgModule } from '@angular/core';

import { TodoListComponent } from './todolist.component';
import { DisplayTodoListItemsComponent } from './display-todolist-items.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    imports: [
        HttpClientModule
    ],
    exports: [
        TodoListComponent
    ],
    declarations: [
        TodoListComponent,
        DisplayTodoListItemsComponent
    ],
    providers: [],
})
export class TodoListModule { }