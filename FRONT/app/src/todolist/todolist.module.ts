import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { TodoListComponent } from './todolist.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NewTodoListItemComponent } from './new-todolist-item.component';

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
        NewTodoListItemComponent
    ],
    providers: [],
})
export class TodoListModule { }