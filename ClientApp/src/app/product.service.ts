import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product, ProductInputModel } from './product';
import { handleError } from './servicehelper';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url = 'api/products';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.url}/${id}`, this.httpOptions).pipe(
      catchError(handleError<Product>('getProduct'))
    );
  }

  getProducts(category?: string, search?: string): Observable<Product[]> {
    let url = this.url;
    if (category) {
      url += `?category=${category}`;
    }
    if (search) {
      url += category ? `&search=${search}` : `?search=${search}`;
    }
    return this.http.get<Product[]>(url, this.httpOptions).pipe(
      catchError(handleError<Product[]>('getProducts'))
    );
  }

  createProduct(product: Product): Observable<Product> {
    const productModel = ProductInputModel.fromProduct(product);
    return this.http.post<Product>(this.url, productModel, this.httpOptions).pipe(
      catchError(handleError<Product>('createProduct'))
    );
  }

  replaceProduct(product: Product): Observable<Product> {
    const productModel = ProductInputModel.fromProduct(product);
    return this.http.put<Product>(`${this.url}/${product.productId}`, productModel, this.httpOptions).pipe(
      catchError(handleError<Product>('replaceProduct'))
    );
  }

  updateProduct(id: number, changes: Map<string, any>): Observable<{}> {
    const patch = [];
    changes.forEach((value, key) => patch.push({ op: 'replace', path: key, value }));
    return this.http.patch(`${this.url}/${id}`, patch).pipe(
      catchError(handleError<{}>('createSupplier')));
  }

}
