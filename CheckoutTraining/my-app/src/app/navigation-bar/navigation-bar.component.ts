import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {

  NavBarHeadings = [
    { id: 1, displayName: 'CHECKOUT' },
    { id: 2, displayName: 'ENABLEMENT' },
    { id: 3, displayName: 'FLIGHTS' },
    { id: 4, displayName: 'CHAI' },
  ];

  constructor() { }

  ngOnInit() {
  }

}
