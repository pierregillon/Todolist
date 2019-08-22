import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { TodoListComponent } from './todolist.component';
import { DisplayTodoListItemsComponent } from './display-todolist-items.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NewTodoListItemComponent } from './new-todolist-item.comonent';

@NgModule({
    imports: [
        HttpClientModule,
        BrowserModule,
        FormsModule
    ],
    exports: [
        TodoListComponent
    ],
    declarations: [
        TodoListComponent,
        DisplayTodoListItemsComponent,
        NewTodoListItemComponent
    ],
    providers: [],
})
export class TodoListModule { }