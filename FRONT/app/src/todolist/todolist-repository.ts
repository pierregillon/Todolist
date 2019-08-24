import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class TodoListRepository {
    constructor(private http:HttpClient) { }

    createNew(value: string) {
        return this.http.post('https://localhost:44346/api/todolist', { description: value }).toPromise();
    }

    edit(id: string, newDescription: string) {
        return this.http.put('https://localhost:44346/api/todolist', { id: id, newDescription: newDescription }).toPromise();
    }

    remove(id: string) {
        return this.http.delete('https://localhost:44346/api/todolist/', { params: {id: id} }).toPromise();
    }

    getAll() : Promise<TodoListItem[]> {
        return this.http.get<TodoListItem[]>('https://localhost:44346/api/todolist').toPromise();
    }
}

export class TodoListItem {
    id: string;
    description: string;
    isDone: boolean;
}