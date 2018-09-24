import { Component} from '@angular/core';
import { filterCarsService } from '../shared/services/filterCar-Service';
import { CarOrderService } from '../shared/services/order-Service';
import { carOrder } from '../shared/models/carOrder-model';

@Component({
  selector: 'car-price',
  templateUrl: './car-price.component.html',
  styleUrls: ['./car-price.component.css']
})
export class CarPriceComponent  {
  carGallery:any={a:""};
  carList:any={a:""};
  carType:any={a:0};
  isRagistared:boolean=false;
  carNotAvailable:boolean=false;
  constructor(private myCarGallery:filterCarsService,private myCarOrderType:CarOrderService) {
    this.carGallery=JSON.parse(localStorage.getItem("selectedCar"));
    this.carList=this.myCarGallery.carInfo;
    if (localStorage.length > 1) {
      this.isRagistared=true;
    }
   }
   carOrder:boolean=false;
   model: any = {};
wrongDateInput:boolean=false;
getPrice:boolean=false;
totalCost:number=0;

BackToGallery(){
  this.myCarGallery.moveToOrder=false;
}

wrongmindate:boolean=false;
moveToOrder(){
  this.carOrder=true;
  console.log(this.orderCar);
}
showedPeice:boolean=true;
getyear:boolean=false;
    onSubmit()
{
 let mindate:Date=new Date();
 let start:Date=new Date(this.model.Start);
 mindate=new Date(mindate.getFullYear(),mindate.getMonth(),mindate.getDate());

  if(start<=mindate){
    this.wrongmindate=true;
    this.showedPeice=true;
  }
  else{
    this.wrongmindate=false;
    this.showedPeice=false;
  }
  if(this.model.Start<this.model.End&&start>=mindate)
  {
    this.showedPeice=false;
   let date1:Date=new Date(this.model.Start)
   let date2:Date=new Date(this.model.End)
   var diff = Math.abs(date1.getTime() - date2.getTime());
   var diffDays = Math.ceil(diff / (1000 * 3600 * 24));
   this.totalCost=diffDays*this.carGallery.DailyCost
   this.wrongDateInput=false;
   this.getPrice=true;
   this.myCarOrderType.getOrder(this.model.Start,this.model.End);
   this.carNotAvailable=false;
  }
  else{
    this.showedPeice=true;
    this.totalCost=null;
    this.wrongDateInput=true;
    this.getPrice=false;
  }
  }
  orderCar:any={};

  order(VehicleNumber:number){
         
    
      let a =localStorage.getItem("username");
      this.carType=this.myCarOrderType.carTyperesult
      
      for(let i in this.carType){
        if(this.carType[i]==VehicleNumber){
          this.carNotAvailable=true;
        }
      }
      if(!this.carNotAvailable){
        this.orderCar.StartDate=this.model.Start;
        this.orderCar.ReturnDate=this.model.End;
        this.orderCar.VehicleNumber=VehicleNumber;
        this.orderCar.UserName=a;
      this.myCarOrderType.sendNewOrder(this.orderCar);
      window.location.href="/cars";

      }
   }
 }
       
     
  
  

