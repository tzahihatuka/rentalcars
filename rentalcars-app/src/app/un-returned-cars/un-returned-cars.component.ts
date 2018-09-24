import { Component, OnInit, Input } from '@angular/core';
import { carOrder } from '../shared/models/carOrder-model';
import { CarOrderService } from '../shared/services/order-Service';
import { carsService } from '../shared/services/cars-Service';

@Component({
  selector: 'un-returned-cars',
  templateUrl: './un-returned-cars.component.html',
  styleUrls: ['./un-returned-cars.component.css']
})
export class UnReturnedCarsComponent implements OnInit {
  model:any={}
  constructor(private myCarGallery:carsService,private myCarOrders:CarOrderService) {
    
   }
  
   ReturnCar(){

   console.log(this.myCarOrders.returnedCar.StartDate) 
   this.myCarOrders.updateanorder(this.myCarOrders.returnedCar)
   }
  
  ngOnInit() {
    }

}
