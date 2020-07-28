import { Supplier } from './supplier';
import { Rating } from './rating';

export class Product {
  constructor(
    productId: number,
    name: string,
    description: string,
    category: string,
    price: number,
    supplier: Supplier,
    ratings?: Rating[]) {

  }
}
