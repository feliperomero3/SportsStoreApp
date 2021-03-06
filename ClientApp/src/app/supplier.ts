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

export class SupplierInputModel {
  name: string;
  city: string;
  state: string;

  static fromSupplier(supplier: Supplier): SupplierInputModel {
    return {
      name: supplier.name,
      city: supplier.city,
      state: supplier.state
    };
  }
}
