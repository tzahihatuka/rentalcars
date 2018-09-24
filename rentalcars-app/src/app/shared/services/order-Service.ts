import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { carOrder } from "../models/carOrder-model";
import { Data } from "@angular/router";

//מאפשר לשירות הנוכחי להשתמש בתוכו בשירותים אחרים
@Injectable()
export class CarOrderService {
    carTyperesult:any={a:""};
    orderlist:any;
    orderselected:any={a:""};
    returnedCar:any={a:""};
    cost:any={a:""};
    orderselectedCost:number;
    isTheselectedOrderAnded:any;
    gutOrder:boolean=false;
    deletedSuccessfully:boolean=false;
    username:string=localStorage.getItem("username");
    constructor(private myHttpClient: HttpClient) {}

    getAllOrders(idNumber:number){
      let apiUrl:string=`http://localhost:55860/api/GetUserOrdesrByidNumber?idNumber=${idNumber}`;
  this.myHttpClient.get(apiUrl,
    {
        headers: new HttpHeaders().set('Authorization',  localStorage.getItem("username")+" "+localStorage.getItem("password"))
   }).subscribe((res:carOrder)=>{ this.orderlist=res},err => {

  });
    }
getUserOrders(){
  let apiUrl:string=`http://localhost:55860/api/GetUserOrdesrByUserName?username=${this.username}`;
  this.myHttpClient.get(apiUrl,
    {
        headers: new HttpHeaders().set('Authorization',  localStorage.getItem("username")+" "+localStorage.getItem("password"))
   }).subscribe((res:carOrder)=>{ this.orderlist=res},err => {

  });
}

getUserOrdersByIdNamber(IdNamber:number){
  let apiUrl:string=`http://localhost:55860/api/GetUserOrdesrByidNumber?idnumber=${IdNamber}`;
  this.myHttpClient.get(apiUrl,
    {
        headers: new HttpHeaders().set('Authorization',  localStorage.getItem("username")+" "+localStorage.getItem("password"))
   }).subscribe((res:carOrder)=>{ this.orderlist=res},err => {

  });
}
GetPrice(StartDate:Data,endDate:Data){
  if(this.orderselected.a.ActualReturnDate!=null){
    endDate=this.orderselected.a.ActualReturnDate
  }
 let diffDays=this.inBetween(StartDate,endDate);
 this.orderselectedCost = diffDays*this.orderselected.a.DailyCost;
 if(this.orderselected.a.ActualReturnDate==null){
  this.isTheselectedOrderAnded="the car has not returned yet"
 }
 else{
  this.isTheselectedOrderAnded=this.orderselected.a.ActualReturnDate;
 }
}
inBetween(date1, date2 ) {
  //Get 1 day in milliseconds
  var one_day=1000*60*60*24;
  // Convert both dates to milliseconds
  var date1_ms = date1.getTime();
  var date2_ms = date2.getTime();
  // Calculate the difference in milliseconds
  var difference_ms = date2_ms - date1_ms;
  // Convert back to days and return
  return Math.round(difference_ms/one_day); 
}

    getOrder(start:Date,end:Date) {
       let apiUrl:string=`http://localhost:55860/api/GetListOrderByDate?start=${start}&&end=${end}`;
      this.myHttpClient.get(apiUrl,
        {
            headers: new HttpHeaders().set('Authorization',  localStorage.getItem("username")+" "+localStorage.getItem("password"))
       }).subscribe((res:number)=>{ this.carTyperesult=res,console.log(res)},err => {

      });
     
    }
    newOrder:boolean=false;;
    sendNewOrder(orderInfo:carOrder) {
        let headers = new HttpHeaders({
          'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
      let options = { headers: headers };
         let apiUrl:string=`http://localhost:55860/api/Order`;
        this.myHttpClient.post(apiUrl, orderInfo,options,)
          .subscribe(
            res => {
              if(res!=null)
              this.newOrder=false;
              else{this.newOrder=true;}
            },
            err => {
              this.newOrder=true;
            }
          );
         
      }

      updateOrder(orderUdate){
        let apiUrl:string=`http://localhost:55860/api/Order`;
        let headers = new HttpHeaders({
          'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
      let options = { headers: headers };
           this.myHttpClient.put<any>(apiUrl, orderUdate, options)
          .subscribe(
            res => {
              if(res!=null)
              this.newOrder=false;
              else{this.newOrder=true;}
              this.cost.a=res;
            },
            err => {
              this.newOrder=true;
            }
          );
      }

      updateanorder(returnedCar:carOrder){
        let apiUrl:string=`http://localhost:55860/api/returnCar`;
        let headers = new HttpHeaders({
          'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
      let options = { headers: headers };
           this.myHttpClient.put<any>(apiUrl, returnedCar, options)
          .subscribe(
            res => {
              this.cost.a=res;
            },
            err => {
             
            }
          );
      }

      deleteOrder(deleteOrder:any){
        let apiUrl:string=`http://localhost:55860/api/Order?username=${deleteOrder.UserName}&&carNumber=${deleteOrder.VehicleNumber}&&start=${deleteOrder.StartDate}`;
        let headers = new HttpHeaders({
          'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
      let options = { headers: headers };
      this.myHttpClient.delete(apiUrl,options)
      .subscribe(
        res => {
          this.cost.a=res;
          this.deletedSuccessfully=false;
        },
        err => {
          this.deletedSuccessfully=true;
        }
      );}
}