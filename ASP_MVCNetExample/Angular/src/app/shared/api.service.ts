import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import MovieModel from './MovieModel';

@Injectable()
export default class ApiService {
  public API = 'http://localhost:44335/api';
  public MOVIE_MODELS_ENDPOINT = `${this.API}/moviemodels`;
  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<MovieModel>> {
    return this.http.get<Array<MovieModel>>(this.MOVIE_MODELS_ENDPOINT);
  }
}
