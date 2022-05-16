import { Routes } from '@angular/router';

import { StatisticsComponent } from '../statistics/statistics.component';
import { WeatherCardsComponent } from '../weather-cards/weather-cards.component';
import { TableWeatherComponent } from '../table-weather/table-weather.component';
import { MapsComponent } from '../maps/maps.component';

export const MainLayoutRoutes: Routes = [
    { path: 'statistics',     component: StatisticsComponent },
    { path: 'weather-cards', component: WeatherCardsComponent },
    { path: 'table-weather',  component: TableWeatherComponent },
    { path: 'maps',           component: MapsComponent }
];
