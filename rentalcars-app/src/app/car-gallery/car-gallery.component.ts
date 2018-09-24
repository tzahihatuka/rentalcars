import { Component, OnInit } from '@angular/core';
import { carsService } from '../shared/services/cars-Service';
import { carModel } from '../shared/models/car-model';
import { forEach } from '@angular/router/src/utils/collection';
import { filterCarsService } from '../shared/services/filterCar-Service';

@Component({
  selector: 'car-gallery',
  templateUrl: './car-gallery.component.html',
  styleUrls: ['./car-gallery.component.css']
})

export class CarGalleryComponent implements OnInit {
  moveToOrder:boolean=false;
  carSelected:boolean=false;
  Selectedcar:number;
  carGallery:any={a:""};
  constructor(private myCarGallery:filterCarsService) {}
  
  ngOnInit() {
    this.carGallery=this.myCarGallery.carInfo;
    }
  selectCar(a:number){
    this.myCarGallery.getSelectedCar(a);
    this.Selectedcar=a
    this.myCarGallery.carSelected=true;
  }
 
  }


