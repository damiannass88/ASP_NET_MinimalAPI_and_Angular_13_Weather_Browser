import { Component, OnInit } from '@angular/core';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/table-weather', title: 'Weather Table', icon: 'design_bullet-list-67', class: '' },
    { path: '/weather-cards', title: 'Weather Card',  icon: 'design_app', class: '' },
    { path: '/statistics', title: 'Statistics', icon: 'education_atom', class: '' },
    { path: '/maps', title: 'Maps', icon: 'location_map-big', class: '' }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ( window.innerWidth > 991) {
          return false;
      }
      return true;
  };
}
