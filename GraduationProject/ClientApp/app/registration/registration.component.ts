import { City } from './../model/city';
import { CitiesService } from './../services/cities.service';
import { AreasService } from './../services/areas.service';
import { Areas } from './../model/areas';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  areas: Areas[];
  cities: City[];
  constructor(private areaService:AreasService, private citiesServices:CitiesService) { 

  }
  passwordConfirmation: boolean=false;
  ngOnInit(): void {
    this.citiesServices.GetCities().subscribe(a => {
      this.cities = a;
    });
  }
  OnRegistration(data:NgForm) {
    console.log(data);
  }
  OComparePasswords(password, confirmPassword) {
    console.log(confirmPassword.value);
    console.log(password.value);
    this.passwordConfirmation = password.value != confirmPassword.value;
    console.log(this.passwordConfirmation);
  }
  OnCityChange(data) {
    if (data.value != 0) {
      this.areaService.GetAreas(data.value).subscribe(a => {
        this.areas = a;
        console.log(a);
      });

    } else
    {
      this.areas = [];  
    }
  }


}
