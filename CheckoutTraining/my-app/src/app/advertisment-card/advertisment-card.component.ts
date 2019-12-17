import { Component, OnInit } from '@angular/core';
import { MockDataService } from '../mock-data.service';

@Component({
  selector: 'app-advertisment-card',
  templateUrl: './advertisment-card.component.html',
  styleUrls: ['./advertisment-card.component.css']
})
export class AdvertismentCardComponent implements OnInit {

  adsList = [];

  constructor(private mockDataService: MockDataService) { }

  ngOnInit() {
    this.mockDataService.sendGetRequest().subscribe((data: any[]) => {
      this.adsList = data;
    });
  }

}
