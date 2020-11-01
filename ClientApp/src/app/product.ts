import { Supplier } from './supplier';
import { Rating } from './rating';

export class Product {
  constructor(
    public productId: number,
    public name: string,
    public description: string,
    public category: string,
    public price: number,
    public supplier: Supplier,
    public ratings?: Rating[]) {

  }
}

export class ProductInputModel {
  name: string;
  description: string;
  category: string;
  price: number;
  supplierId: number;

  static fromProduct(product: Product): ProductInputModel {
    return {
      name: product.name,
      description: product.description,
      category: product.category,
      price: product.price,
      supplierId: product.supplier ? product.supplier.supplierId : 0
    };
  }
}
