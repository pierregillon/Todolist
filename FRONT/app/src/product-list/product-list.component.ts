import { Component, OnInit } from '@angular/core';
import { ProductRepository } from './product-repository'

@Component({
    selector: 'product-list',
    templateUrl: './product-list.component.html',
    providers:  [ ProductRepository ]
})

export class ProductListComponent implements OnInit {
    products: any;
    constructor(private repository: ProductRepository) { 
        repository.getAll().then (products => {
            this.products = products;
        });
    }

    ngOnInit() { }
}