import { Component, OnInit } from '@angular/core';
import { ProductRepository, Product } from './product-repository'

@Component({
    selector: 'product-list',
    templateUrl: './product-list.component.html',
    providers:  [ ProductRepository ]
})

export class ProductListComponent implements OnInit {
    products:Product[];

    constructor(private repository: ProductRepository) { }

    ngOnInit() { 
        this.repository.getAll().then (products => {
            this.products = products;
        });
    }
}