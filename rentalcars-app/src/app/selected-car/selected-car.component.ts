import { Component, OnInit } from '@angular/core';
import { filterCarsService } from '../shared/services/filterCar-Service';

@Component({
  selector: 'selected-car',
  templateUrl: './selected-car.component.html',
  styleUrls: ['./selected-car.component.css']
})
export class SelectedCarComponent implements OnInit {
  isRagistared:boolean=false;
  carGallery:any={a:""};
  constructor(private myCarGallery:filterCarsService) {
    if(!this.myCarGallery.carSelected){
      window.location.href="/cars";
    }
    
  }

  ngOnInit() {
    if (localStorage.length > 1) {
      var v = localStorage.getItem("Authorize");
      this.isRagistared=true;
      }
     this.carGallery=JSON.parse(localStorage.getItem("selectedCar"));
  }
  openOrderBox(){
    this.myCarGallery.carSelected=false;
    this.myCarGallery.moveToOrder=true;
  }
  closeselectCar(){
    this.myCarGallery.carSelected=false;
  }
}