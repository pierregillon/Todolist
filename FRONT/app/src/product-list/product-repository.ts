import { Injectable } from '@angular/core';

@Injectable()
export class ProductRepository {
    constructor() { }

    getAll() {
        return new Promise(function(resolve) {
            var products = [
                {name: 'Corsair Gaming Headset', type: 'Video game accessories', price: 59},
                {name: 'Black chair', type: 'Furniture', price: 120},
                {name: 'Iphone 12', type: 'Hightech', price: 1020 }
            ];
            resolve(products);
        });
    }
}