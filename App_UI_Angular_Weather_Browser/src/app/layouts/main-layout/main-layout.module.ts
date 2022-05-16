import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MainLayoutRoutes } from './main-layout.routing';
import { StatisticsComponent } from '../statistics/statistics.component';
import { WeatherCardsComponent } from '../weather-cards/weather-cards.component';
import { TableWeatherComponent } from '../table-weather/table-weather.component';
import { MapsComponent } from '../maps/maps.component';
import { ChartsModule } from 'ng2-charts';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(MainLayoutRoutes),
    FormsModule,
    ChartsModule,
    NgbModule,
    ToastrModule.forRoot()
  ],
  declarations: [
    StatisticsComponent,
    WeatherCardsComponent,
    TableWeatherComponent,
    MapsComponent,
  ]
})

export class MainLayoutModule {}
