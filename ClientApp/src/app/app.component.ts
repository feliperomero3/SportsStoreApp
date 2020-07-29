import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';
import { Product } from './product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Products Catalog';
  product: Product;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProduct(1);
  }

  getProduct(id: number): void {
    this.productService.getProduct(id).subscribe(p => this.product = p);
  }

}
