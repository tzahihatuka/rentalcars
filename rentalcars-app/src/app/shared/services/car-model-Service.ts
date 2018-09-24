import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { carModel } from "../models/car-model";


@Injectable()
export class carsModel {
 
    TypeName:any={a:""};
    TypsModel:any={a:""};
    TypsGetGear:any={a:""};
    TypsGetYear:any={a:Date};
    constructor(private myHttpClient: HttpClient) {
        this.getCarTypsGetGear();
        this.getCarTypsGetYear();
    }

    getCarTyps(): void {
        let apiUrl:string=`http://localhost:55860/api/TypeName`;
        this.myHttpClient.get(apiUrl)
            .subscribe((x: any) => {this.TypeName.a=x });
    }


    getCarTypsModel(CompanynName:String): void {
        let apiUrl:string=`http://localhost:55860/api/TypeName?id=${CompanynName}`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x: any) => {this.TypsModel.a=x ,console.log(x)});
    }
    getListCarTypsModel(CompanynName:String) {
        let apiUrl:string=`http://localhost:55860/api/CarType?id=${CompanynName}`;
        
      return  this.myHttpClient.get(apiUrl)
    }


    getCarTypsGetGear(): void {
        let apiUrl:string=`http://localhost:55860/api/GetGear`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x: any) => {this.TypsGetGear.a=x });
    }
    getCarTypsGetYear(): void {
        let apiUrl:string=`http://localhost:55860/api/GetYear`;
        this.myHttpClient.get(apiUrl)
            .subscribe((x: any) => {this.TypsGetYear.a=x});
    }


    addnewType(newCarType){
        console.log(newCarType);
        let headers = new HttpHeaders({
            'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
        let options = { headers: headers };
           let apiUrl:string=`http://localhost:55860/api/CarType`;
          this.myHttpClient.post(apiUrl, newCarType,options,)
            .subscribe(
              res => {
              console.log(res);
              if(res!=null){
                 
              }
              else{
               
              }
              },
              err => {
              }
            );
        }
        UpdatenewType(arrUpdate: any) {
            let apiUrl:string=`http://localhost:55860/api/CarType`;
            let headers = new HttpHeaders({
              'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
          let options = { headers: headers };
               this.myHttpClient.put<any>(apiUrl, arrUpdate, options)
              .subscribe(
                res => {
                },
                err => {
                 
                }
              );
        }
       
     //   <td>{{this.order.ManufactureYear|date:'M/d/yy'}}</td>
     //   <td>{{this.order.DailyCost}}</td>
     //   <td>{{this.order.CostDayOverdue}}</td>
        
      deleteCarType(deleteCarType:any){
        let apiUrl:string=`http://localhost:55860/api/CarType?ManufacturerName=${deleteCarType.ManufacturerName}&&Model=${deleteCarType.Model}&&Gear=${deleteCarType.Gear}&&ManufactureYear=${deleteCarType.ManufactureYear}&&DailyCost=${deleteCarType.DailyCost}&&CostDayOverdue=${deleteCarType.CostDayOverdue}`;
        let headers = new HttpHeaders({
          'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
      let options = { headers: headers };
      this.myHttpClient.delete(apiUrl,options)
      .subscribe(
        res => {
        },
        err => {
        }
      );}
}