import { Component, OnInit, Input } from '@angular/core';
import { CarOrderService } from '../shared/services/order-Service';
import { carsService } from '../shared/services/cars-Service';
import { carOrder } from '../shared/models/carOrder-model';
import { ActivatedRoute } from '@angular/router';
import { carModel } from '../shared/models/car-model';

@Component({
  selector: 'order-preview',
  templateUrl: './order-preview.component.html',
  styleUrls: ['./order-preview.component.css']
})
export class OrderPreviewComponent implements OnInit {

  @Input() order;
  constructor(private myCarOrders:CarOrderService) {
    
    if(!myCarOrders.gutOrder){
      window.location.href="/MyOrders";
    }
  }
  ngOnInit() {
    
  }
}

