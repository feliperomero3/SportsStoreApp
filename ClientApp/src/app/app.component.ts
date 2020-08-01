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
  products: Product[];
  filter: { category?: string, search?: string };

  constructor(private productService: ProductService) {
    this.filter = { category: 'Football' };
  }

  ngOnInit(): void {
    this.getProducts();
  }

  getProduct(id: number): void {
    this.productService.getProduct(id).subscribe(product => this.product = product);
  }

  getProducts(): void {
    this.productService.getProducts(this.filter.category, this.filter.search)
      .subscribe(products => this.products = products);
  }

}
