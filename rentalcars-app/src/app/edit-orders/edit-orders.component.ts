import { Component} from '@angular/core';
import { carOrder } from '../shared/models/carOrder-model';
import { CarOrderService } from '../shared/services/order-Service';

@Component({
  selector: 'edit-orders',
  templateUrl: './edit-orders.component.html',
  styleUrls: ['./edit-orders.component.css']
})
export class EditOrdersComponent {
  model: any = {};
  wrongDateInput:boolean=false;
  wrongmindate:boolean=false;
  wrongCarinput:boolean=false;
  orderlist:any;
  date:any={};
  serchresult:boolean=false;
 
  constructor(private myCarOrders:CarOrderService) {
   }
   search(){
     if(this.model.IdNamber!=null)
     {
       this.serchresult=true
      this.myCarOrders.getUserOrdersByIdNamber(this.model.IdNamber);
      setTimeout(() => {
        this.orderlist=this.myCarOrders.orderlist;
        this.model.UserName=this.orderlist[0].UserName
      },1000);
     }
    
   }
   getdetels:any={};



  onSubmit(order)
  {
    if( this.model.VehicleNumber==null){
    this.model.VehicleNumber=0;
  }
   let mindate:Date=new Date();
   let StartDate:Date=new Date(this.date.Start);
   mindate=new Date(mindate.getFullYear(),mindate.getMonth(),mindate.getDate());
   this.wrongDateInput=false;
    this.wrongmindate=false;
    if(StartDate<=mindate){
      this.wrongmindate=true;
    }
    else{
      this.wrongmindate=false;
    }
    if(this.date.Start<this.date.Return)
    {
     this.wrongDateInput=false;
    }
    else {
      this.wrongDateInput=true;
    }
 
    if(!this.wrongDateInput&&!this.wrongmindate){
    switch (order){
      case "Add": this.add();break;
      case "Update": this.Update();break;
      default:break;
    }
    } 
    }

 add(){
   if( this.model.VehicleNumber!=0){
    this.wrongCarinput=false;
    this.model.StartDate=this.date.Start;
    this.model.ReturnDate=this.date.Return;
    this.myCarOrders.sendNewOrder(this.model);
    this.search();
   }
   
   if( this.model.VehicleNumber==0){
    this.wrongCarinput=true; 
   }

 }
 Update(){
  if( this.model.VehicleNumber!=0){
    this.wrongCarinput=false;
    this.model.oldStart=this.model.StartDate;
    this.model.StartDate=this.date.Start;
    this.model.ReturnDate=this.date.Return;
    this.myCarOrders.updateOrder(this.model);
   }
   
   if( this.model.VehicleNumber==0){
    this.wrongCarinput=true; 
    this.search();
   }

 }
fordelete:any;
    setItem(str){
     
      this.fordelete=str;
      this.model.StartDate=str.StartDate;
      this.model.ReturnDate=str.ReturnDate;
      this.model.VehicleNumber=str.VehicleNumber;
      this.model.UserName=str.UserName;
      this.model.ActualReturnDate=str.ActualReturnDate;
      this.orderlist={a:""};
      this.orderlist=[this.model];
     
  }
  deleteOrder(){
if(this.fordelete!=undefined){
  this.myCarOrders.deleteOrder(this.fordelete);
  setTimeout(() => {
    this.fordelete={};
    this.search();
  }, 200);
}


  }

}
