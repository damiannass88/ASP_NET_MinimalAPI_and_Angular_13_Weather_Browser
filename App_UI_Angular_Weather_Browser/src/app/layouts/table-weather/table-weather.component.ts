import { Component, OnInit } from '@angular/core';
import { RestApiService } from '../../services/rest-api.service';

@Component({
  selector: 'app-table-weather',
  templateUrl: './table-weather.component.html',
  styleUrls: ['./table-weather.component.css']
})
export class TableWeatherComponent implements OnInit {
  Weather: any = [];
  constructor(public restApi: RestApiService) { }

  ngOnInit() {
    this.loadWeathers();
  }

  // Get weathers list
  loadWeathers() {
    return this.restApi.getWeathers().subscribe((data: {}) => {
      this.Weather = data;
    });
  }
}
