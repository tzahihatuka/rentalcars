import { Injectable } from "@angular/core";
import { carsService } from "./cars-Service";
import { HttpClient } from "@angular/common/http";



@Injectable()
export class filterCarsService {
    moveToOrder:boolean=false;
    carSelected:boolean=false;
    carlist:any={a:""};
    carInfo:any={a:""};
    constructor(private myCarGallery:carsService,private myHttpClient: HttpClient) {
        this.myCarGallery.getGars();
        this.carlist=this.carInfo;
    }
getCarList(){
    this.myCarGallery.getGars();
    this.carInfo=this.myCarGallery.carInfo;
}

    getFilterdCarGars(a:any): void { 
            let apiUrl:string=`http://localhost:55860/api/FilteredCars?Company=${a.Company}&&Gear=${a.Gear}&&Model=${a.Model}&&openText=${a.openText}&&Year=${a.Year}`;
            
            this.myHttpClient.get(apiUrl)
                .subscribe((x: any) => {this.carInfo.a=x});
        } 
    
 
getSelectedCar(VehicleNumber:number){
this.carlist = this.carInfo.a.filter(
    car => car.VehicleNumber == VehicleNumber);

    localStorage.setItem("selectedCar",JSON.stringify(this.carlist[0]));
}

}
