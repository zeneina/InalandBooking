import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'http://localhost:4200/';
  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    const loginUrl = `${this.apiUrl}/login`;
    const credentials = { username, password };
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.post<any>(loginUrl, credentials, httpOptions)
      .pipe(
        catchError(this.handleError) // Χειρισμός σφαλμάτων
      );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'Συνέβη κάποιο σφάλμα.';

    if (error.error instanceof ErrorEvent) {
      // Σφάλμα δικτύου ή σφάλμα στη διεύθυνση URL του server
      errorMessage = `Σφάλμα: ${error.error.message}`;
    } else {
      // Το backend επέστρεψε κωδικό σφάλματος απόκρισης
      errorMessage = `Κωδικός σφάλματος: ${error.status}, Μήνυμα: ${error.error}`;
    }
    console.error(errorMessage);

    return (errorMessage);
  }
}
