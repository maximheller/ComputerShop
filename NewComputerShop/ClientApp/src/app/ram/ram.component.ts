import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-ram',
  templateUrl: './ram.component.html'
})
export class RamComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    http.get<WeatherForecast[]>(baseUrl + 'ram').subscribe(result => {
      this.forecasts = result;
      console.log(result);
    }, error => console.error(error));

  }

}


interface WeatherForecast {
  memoryCapacity: number;
  frequency: number;
 
}
