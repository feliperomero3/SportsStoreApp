import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';
import { Product } from './product';
import { Supplier } from './supplier';
import { SupplierService } from './supplier.service';

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

  constructor(private productService: ProductService, private supplierService: SupplierService) {
    this.filter = { category: '' };
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

  createProduct(): void {
    const newProduct = new Product(0, 'X-Ray Scuba Mask', 'Watersports',
      'See what the fish are hiding', 49.99, this.products[0].supplier);

    this.productService.createProduct(newProduct).subscribe(() => this.getProducts());
  }

  createProductAndSupplier(): void {
    const newSupplier = new Supplier(0, 'Rocket Shoe Corp', 'Boston', 'MA');

    this.supplierService.createSupplier(newSupplier).subscribe(
      (createdSupplier: Supplier) => {
        const product = new Product(0, 'Rocket-Powered Shoes', 'Running', 'Set a new record', 100, createdSupplier);
        this.productService.createProduct(product).subscribe(() => this.getProducts());
      }
    );
  }

  replaceProduct(): void {
    const product = this.products[0];
    product.name = `Modified ${product.name}`;
    product.description = `Modified ${product.description}`;
    product.category = `Modified ${product.category}`;
    this.productService.replaceProduct(product).subscribe(() => this.getProducts());
  }

  replaceSupplier(): void {
    const supplier = this.products[0].supplier;
    supplier.name = `Modified ${supplier.name}`;
    this.supplierService.replaceSupplier(supplier).subscribe(() => this.getProducts());
  }

}
