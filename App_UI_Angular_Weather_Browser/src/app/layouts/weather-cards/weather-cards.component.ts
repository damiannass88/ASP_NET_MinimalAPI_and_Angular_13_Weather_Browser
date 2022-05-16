import { Component, OnInit } from '@angular/core';
import { RestApiService } from '../../services/rest-api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './weather-cards.component.html',
  styleUrls: ['./weather-cards.component.css']
})

export class WeatherCardsComponent implements OnInit {
  Weather: any = [];

  path_city: string = '../../assets/img/city-live/';
  path_weather: string = '../../assets/img/weather-live/';
  imgs: string[] = ['1.jpg', '2.jpg', '3.jpg', '4.jpg', '5.jpg', '6.jpg'];
 
  constructor(public restApi: RestApiService) { }

  ngOnInit() {
    this.loadWeathers(); 
  }

  // Get weathers list
  loadWeathers() {
    return this.restApi.getWeathers().subscribe((data: {}) => {
      this.Weather = data;
      this.AddLive();
    });
  } 
  AddLive() {
    this.Weather.map(a => { a.liveCity = this.RandomCity(), a.liveWeather = this.RandomWeather() });
  }
  Random() {
    return Math.floor(Math.random() * this.imgs.length);
  }
  RandomWeather() {
    return this.path_weather + this.imgs[this.Random()];
  }
  RandomCity() {
    return this.path_city + this.imgs[this.Random()];
  } 
}
