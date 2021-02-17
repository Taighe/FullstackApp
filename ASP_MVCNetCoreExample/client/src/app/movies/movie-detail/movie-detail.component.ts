import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../../_models/movie';
import { MoviesService } from '../../_services/movies.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {
  movie: Movie;

  constructor(private moviesService: MoviesService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMovie();
  }

  loadMovie() {
    this.moviesService.getMovie(this.route.snapshot.paramMap.get('id')).subscribe(movie => {
      this.movie = movie;
    })
  }

}
