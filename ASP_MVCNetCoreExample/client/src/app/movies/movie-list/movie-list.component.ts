import { Component, OnInit } from '@angular/core';
import { Movie } from '../../_models/movie';
import { MoviesService } from '../../_services/movies.service';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {
  movies: Movie[];
  constructor(private movieService: MoviesService) { }

  ngOnInit(): void {
    this.loadMovies();
  }

  loadMovies() {
    this.movieService.getMovies().subscribe(movies => {
      this.movies = movies;
    })
  }

}
