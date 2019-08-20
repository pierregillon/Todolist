import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductRepository, Product } from './product-repository'

@Component({
    selector: 'product-details',
    templateUrl: './product-details.component.html',
    providers:  [ ProductRepository ]
})

export class ProductDetailsComponent implements OnInit {
    productId: number;
    productName: string;
    productType: string;
    productPrice:number;
    
    constructor(private route: ActivatedRoute, private repository: ProductRepository) {}

    ngOnInit() { 
        this.route.paramMap.subscribe(async params => {
            var productId = parseInt(params.get('productId'));
            var details = await this.repository.getDetails(productId);
            this.productId = details.id;
            this.productName = details.name;
            this.productType = details.type;
            this.productPrice = details.price;
        });
    }
}