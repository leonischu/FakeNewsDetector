import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  private apiUrl = 'https://localhost:7252/api/news/analyze';

  constructor(private http: HttpClient) {}

  analyze(text: string): Observable<any> {
    return this.http.post(this.apiUrl, {
      articleText: text
    });
  }
}