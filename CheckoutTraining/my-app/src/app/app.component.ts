import { Component } from '@angular/core';
import { Gender } from './models/gender.enum';
import { Countries } from './models/countries.enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'my-app';

  color: string = "#fefefe";
  fName: string = "Madhusudan";
  lName: string = "Rathore";

  isDisabled: boolean = false;

  userGender: Gender = Gender.male;
  selectedCountry: Countries = Countries.india;

  toggleButton(): void {
    this.isDisabled = this.isDisabled ? false : true;
  }

}
