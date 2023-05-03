import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-ram-create',
  templateUrl: './ram-create.component.html'
})


export class RamCreateComponent {

  manufacturerId: number = 0;
  memoryCapacity: number = 0;
  frequency: number = 0;
  name: string = "";
  description: string = "";
  price: number = 0;

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  //  //http.get<Phone[]>(baseUrl + 'api/weatherforecast').subscribe(result => {
  //  //  this.forecasts = result;
  //  //}, error => console.error(error));
  //  console.log(baseUrl);
  //}

  constructor(private http: HttpClient) { }

  addPhone() {


    //let formData: FormData = new FormData();
    //formData.append('pfile', file);

    //const headers = new HttpHeaders({
    //  'Content-Type': 'multipart/form-data',
    //  'Accept': 'application/json'
    //});


    let ram = new RamEntity(
      this.manufacturerId,
      this.memoryCapacity,
      this.frequency,
      this.name,
      this.description,
      this.price
    );

    console.log(ram);
    // this.http.post('api/UploadFiles/UploadFiles/', body, options).pipe(map(data => { return data; }));

    this.http.post('api/ram', ram)
      .pipe(map(data => { return data; }))
      .subscribe(result => {
        console.log(result);
      });

  }

}


export class RamEntity {

  constructor(public manufacturerId: number,
    public memoryCapacity: number,
    public frequency: number,
    public name: string,
    public description: string,
    public price: number) {
  }

}

