import { Component, OnInit } from '@angular/core';
import { CarOrderService } from '../shared/services/order-Service';
import { carsService } from '../shared/services/cars-Service';
import { carOrder } from '../shared/models/carOrder-model';

@Component({
  selector: 'my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.css']
})
export class MyOrdersComponent implements OnInit {
 
  orderlist:carOrder;
  constructor(private myCarOrders:CarOrderService,private myCarGallery:carsService) {
    this.orderlist=this.myCarOrders.orderlist;
    this.myCarOrders.getUserOrders();
  }
  ngOnInit() {
  
  
  setTimeout(() => {
    this.myCarGallery.GetCarListByVehicleNumber1(this.myCarOrders.orderlist); 
  },100);
  }
  selectedOrder:any=888;
  
  setItem(str){
    setTimeout(() => {
    this.myCarOrders.GetPrice(new Date(str.StartDate) ,new Date(str.endDate));
  },30);
    this.selectedOrder=str;
    this.myCarOrders.gutOrder=true;
    this.myCarOrders.orderselected.a=this.selectedOrder;

}
}
