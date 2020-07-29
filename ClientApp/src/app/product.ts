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
