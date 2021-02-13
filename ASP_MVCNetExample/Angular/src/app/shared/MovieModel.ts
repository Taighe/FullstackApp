export default class MovieModel {
  id: number;
  name: string;
  releaseDate: string;

  constructor(id: number, name: string, releaseDate: string) {
    this.id = id;
    this.name = name;
    this.releaseDate = releaseDate;
  }
}
