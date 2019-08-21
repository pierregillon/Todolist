import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class TodoListRepository {
    constructor(private http:HttpClient) { }

    getAll() : Promise<TodoListItem[]> {
        return this.http.get<TodoListItem[]>('http://localhost:9999/api/todolist').toPromise();
    }
}

export class TodoListItem {
    
}