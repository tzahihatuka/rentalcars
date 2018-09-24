import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { carModel } from "../models/car-model";
import { carOrder } from "../models/carOrder-model";


@Injectable()
export class carsService {
    carInfo:any={a:""};
    carById:any={a:""};
    constructor(private myHttpClient: HttpClient) {}

    getGars(): void {
        let apiUrl:string=`http://localhost:55860/api/CarInventory?from=0&&to=52`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x: carModel) => {this.carInfo.a=x});
    }

    getCarByNumber(carNumber:number): void {
        let apiUrl:string=`http://localhost:55860/api/CarInventory?carNumber=${carNumber}`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x: carModel) => {this.carInfo.a=x},err => {this.carInfo={a:""}});
    }

GetCarListByVehicleNumber1(orderlist:carOrder){
let a={orderlist}
    if(this.carById.length>0){return;}
    let apiUrl:string=`http://localhost:55860/api/CarInventory?orderlist=${JSON.stringify(a)}`;
this.myHttpClient.get(apiUrl,
{
    headers: new HttpHeaders().set('Authorization',  localStorage.getItem("username")+" "+localStorage.getItem("password"))
}).subscribe((res:any)=>{this.carById.a=res},err => {this.carInfo={a:""}});
}


uplodedCar:boolean=false;
addNewCar(newCar:carModel){
    console.log(newCar);
    let headers = new HttpHeaders({
        'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
    let options = { headers: headers };
       let apiUrl:string=`http://localhost:55860/api/CarInventory`;
      this.myHttpClient.post(apiUrl, newCar,options,)
        .subscribe(
          res => {
          console.log(res);
          if(res!=null){
              this.uplodedCar=false;
          }
          else{
            this.uplodedCar=true;
          }
          },
          err => {
            this.uplodedCar=true;
          }
        );
    }

    updateanCar(updateCar:Array<any>){
        let apiUrl:string=`http://localhost:55860/api/CarInventory`;
        let headers = new HttpHeaders({
          'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
      let options = { headers: headers };
           this.myHttpClient.put<any>(apiUrl, updateCar, options)
          .subscribe(
            res => {
                if(res!=null){
                    this.uplodedCar=false;
                }
                else{
                  this.uplodedCar=true;
                }
                },
                err => {
                  this.uplodedCar=true;
                }
          );
      }

      deletecar(VehicleNumber:number){
        let apiUrl:string=`http://localhost:55860/api/CarInventory?CarNumber=${VehicleNumber}`;
        let headers = new HttpHeaders({
          'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
      let options = { headers: headers };
      this.myHttpClient.delete(apiUrl,options)
      .subscribe(
        res => {
            if(res!=0){
                this.uplodedCar=false;
            }
            else{
              this.uplodedCar=true;
            }
            },
            err => {
              this.uplodedCar=true;
            }
      );}
}