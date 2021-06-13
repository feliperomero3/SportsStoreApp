import { of } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';

/**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
export function handleError<T>(operation: string, result?: T): (error: any) => Observable<T> {
  return (error: any): Observable<T> => {
    console.log(`${operation} caused an error`);
    console.error(JSON.stringify(error));

    // Let the app keep running by returning an empty result.
    return of(result);
  };
}
