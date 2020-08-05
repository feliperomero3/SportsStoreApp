import { Product } from './product';

export class Supplier {
  constructor(
    public supplierId: number,
    public name: string,
    public city: string,
    public state: string,
    public products?: Product[]) {
  }
}
