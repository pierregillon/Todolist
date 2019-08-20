import { Injectable } from '@angular/core';

@Injectable()
export class ProductRepository {
    constructor() { }

    getAll() : Promise<Product[]> {
        return new Promise(function(resolve) {
            var products = [
                new Product(1, 'Corsair Gaming Headset', 'Video game accessories', 59),
                new Product(2, 'Black chair', 'Furniture', 120),
                new Product(3, 'Iphone 12', 'Hightech', 1020)
            ];
            resolve(products);
        });
    }

    async getDetails(productId:number) : Promise<Product> {
        const products = await this.getAll();
        return new Promise(function (resolve) {
            var results = products.filter(x => { return x.id == productId; });
            resolve(results[0]);
        });
    }
}

export class Product {
    constructor(public id: number, public name:string, public type:string, public price:number) { }
}