import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Product, ProductInputModel as ProductInputModel } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url = 'api/products';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  constructor(private http: HttpClient) { }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.url}/${id}`, this.httpOptions).pipe(
      catchError(this.handleError<Product>('getProduct'))
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
      catchError(this.handleError<Product[]>('getProducts'))
    );
  }

  createProduct(product: Product): Observable<Product> {
    const productModel = ProductInputModel.fromProduct(product);
    return this.http.post<Product>(this.url, productModel, this.httpOptions).pipe(
      catchError(this.handleError<Product>('createProduct'))
    );
  }

  replaceProduct(product: Product): Observable<Product> {
    const productModel = ProductInputModel.fromProduct(product);
    return this.http.put<Product>(this.url, productModel, this.httpOptions).pipe(
      catchError(this.handleError<Product>('replaceProduct'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T): (error: any) => Observable<T> {
    return (error: any): Observable<T> => {
      console.log(operation);
      console.error(error);

      // Let the app keep running by returning an empty result.
      return of(result);
    };
  }
}
