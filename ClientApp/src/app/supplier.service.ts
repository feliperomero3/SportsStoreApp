import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Supplier, SupplierInputModel } from './supplier';
import { handleError } from './servicehelper';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  private url = 'api/suppliers';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  constructor(private http: HttpClient) { }

  createSupplier(supplier: Supplier): Observable<Supplier> {
    return this.http.post<Supplier>(this.url, supplier, this.httpOptions).pipe(
      catchError(handleError<Supplier>('createSupplier'))
    );
  }

  replaceSupplier(supplier: Supplier): Observable<Supplier> {
    const supplierModel = SupplierInputModel.fromSupplier(supplier);
    return this.http.put<Supplier>(`${this.url}/${supplier.supplierId}`, supplierModel, this.httpOptions).pipe(
      catchError(handleError<Supplier>('replaceSupplier'))
    );
  }

  deleteSupplier(id: number): Observable<{}> {
    return this.http.delete(`${this.url}/${id}`, this.httpOptions).pipe(
      catchError(handleError<Supplier>('deleteSupplier'))
    );
  }
}
