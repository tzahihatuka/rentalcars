import { Component, OnInit } from '@angular/core';
import { CarOrderService } from '../shared/services/order-Service';
import { carOrder } from '../shared/models/carOrder-model';
import { carsService } from '../shared/services/cars-Service';

@Component({
  selector: 'return-car',
  templateUrl: './return-car.component.html',
  styleUrls: ['./return-car.component.css']
})
export class ReturnCarComponent implements OnInit {

  model:any={}
  orderlist:carOrder;
  constructor(private myCarOrders:CarOrderService,private myCarGallery:carsService) {
   if(location.pathname!="/return-car")
    location.replace("/return-car")
   }
   selectedOrder:any=888;
   setItem(str){
    this.myCarGallery.getCarByNumber(str.VehicleNumber);
    this.selectedOrder=str;
    this.myCarOrders.gutOrder=true;
    this.myCarOrders.returnedCar=str;
    
}
emptyOrderList=false;
  onSubmit(){
   this.myCarOrders.getUserOrdersByIdNamber(this.model.IdNamber);
   
   setTimeout(() => {
    this.orderlist=this.myCarOrders.orderlist;
    if(this.orderlist==null){
      this.emptyOrderList=true;
    }
     
    
  },100);
  }
  ngOnInit() {
    }
 

}
