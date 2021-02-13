import { Component, OnInit } from '@angular/core';
import ApiService from './shared/api.service';
import MovieModel from './shared/MovieModel';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  movieModels: Array<MovieModel> = [];

  constructor(private apiService: ApiService) {
  }

  ngOnInit() {
    this.apiService.getAll().subscribe(data => { this.movieModels = data; });
  }
}
