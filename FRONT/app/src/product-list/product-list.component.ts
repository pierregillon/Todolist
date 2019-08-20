import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'product-list',
    templateUrl: './product-list.component.html'
})

export class ProductListComponent implements OnInit {
    products = [
        {name: 'Corsair Gaming Headset', type: 'Video game accessories', price: 59},
        {name: 'Black chair', type: 'Furniture', price: 120},
        {name: 'Iphone 12', type: 'Hightech', price: 1020 }
    ];

    constructor() { }
    ngOnInit() { }
}