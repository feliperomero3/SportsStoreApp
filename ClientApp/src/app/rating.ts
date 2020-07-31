import { Product } from './product';

export class Rating {
  constructor(
    public ratingId: number,
    public stars: number,
    public product: Product) {

  }
}
