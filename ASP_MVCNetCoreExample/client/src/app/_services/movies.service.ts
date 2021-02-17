import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

import { Movie } from '../_models/movie';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getMovies() {
    return this.http.get<Movie[]>(this.baseUrl + 'movies')
  }

  getMovie(id: string) {
    return this.http.get<Movie>(this.baseUrl + 'movies/' + id)
  }
}
