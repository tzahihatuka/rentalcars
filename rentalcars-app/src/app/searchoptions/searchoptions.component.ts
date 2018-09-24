import { Component, OnInit, HostListener } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap/datepicker/ngb-date';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { filterCarsService } from '../shared/services/filterCar-Service';
import { carsModel } from '../shared/services/car-model-Service';
import { getLoginService } from '../shared/services/login-servece';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'searchoptions',
  templateUrl: './searchoptions.component.html',
  styleUrls: ['./searchoptions.component.css']
})
export class SearchoptionsComponent implements OnInit {
  public minDate: NgbDateStruct ; 
  public maxDate: NgbDateStruct ; 

  hoveredDate: NgbDate;
  date=new Date();
  year=this.date.getFullYear();
  month=this.date.getMonth()+1;
  day=this.date.getDate();
  fromDate: NgbDate;
  toDate: NgbDate;
  carGallery:any={a:""};
  TypsModel:any={a:""};
  TypsGetGear:any={a:""};
  pipe = new DatePipe('en-US');
  TypsGetYear:any={a:Date};
  constructor(private myCarGallery:filterCarsService,private myCarModel:carsModel) {
   
    this.myCarGallery.getCarList();
    this.carGallery=this.myCarModel.TypeName;
    this.TypsModel=this.myCarModel.TypsModel;
this.TypsGetGear=this.myCarModel.TypsGetGear;
this.TypsGetYear=this.myCarModel.TypsGetYear;
    this.date=new Date();
    this.year=this.date.getFullYear();
    this.month=this.date.getMonth()+1;
    this.day=this.date.getDate();
    this.minDate = {
      "year": this.year,
      "month": this.month,
      "day": this.day
    };
    this.maxDate = {
      "year": this.year+1,
      "month": this.month,
      "day": this.day
    };
   }

   Company:string;
   Gear:string;
   Year:Date;
   Model:string;
  openText:string;

   startrent:string;
   endrent:string;
  showcalender:boolean=false;
  toggle(){
    if(this.showcalender){
      this.showcalender=false;
    }
    else{
      this.showcalender=true;
    }
  }
  showDateCalinder:boolean=false;
clickedOnselaction:number=0;
tamp;
dayTamp;
saverange(){

  this.myCarModel.getCarTypsModel(this.Company);

}
searchData:any={ 
  Company:"",
  Gear:"",
  Model:"",
  openText:"",
 Year:new Date(2000+"-"+1+"-"+1),
};
search(){
  this.searchData.Company=this.Company!=undefined?this.Company:null;
  this.searchData.Gear=this.Gear!=undefined?this.Gear:null;
  this.searchData.Model=this.Model!=undefined?this.Model:null;
  this.searchData.Year=this.Year!=undefined?this.Year:null;
  this.searchData.openText=this.openText!=undefined?this.openText:null;
this.myCarGallery.getFilterdCarGars(this.searchData);

  if(window.innerWidth<=991){
  if(this.openInMobile){
    this.openInMobile=false;
  }
  else{
    this.openInMobile=true;
  }
}
}
  onDateSelection(date) {
    if(this.clickedOnselaction==0)
    {
       this.tamp=date;
       this.dayTamp=this.tamp.day-1;
    }
    else{this.dayTamp=this.tamp.day}
    
    this.clickedOnselaction++;
   if(this.tamp.year==date.year&&this.tamp.month==date.month&&this.dayTamp<date.day ||this.tamp.year==date.year&&this.tamp.month<date.month||this.tamp.year<date.year){
     if(this.clickedOnselaction==1){
      console.log("the start");
      this.fromDate=date;
      console.log(date);
     }
     else{
      console.log("the end");
      console.log(date);
      this.toDate=date;
      this.showDateCalinder=true;
      this.startrent=this.fromDate.day+"/"+this.fromDate.month+"/"+this.fromDate.year;
      this.endrent=this.toDate.day+"/"+this.toDate.month+"/"+this.toDate.year;
     }
   }
   else{
    this.clickedOnselaction=1;
    console.log("replace the start");
    console.log(date);
    this.tamp.day=date.day;
   }
   if(this.clickedOnselaction>=2){
    this.showcalender=false;
    this.clickedOnselaction=0;
  }
  }
openOnyOnscad:boolean=false;
openInMobile:boolean=false;

  ngOnInit() {
    if(window.innerWidth<520){

      this.openOnyOnscad=true;
    }
   
    else{
      this.openOnyOnscad=false;
    }
    if(window.innerWidth<850){
      this.openInMobile=true;
    }
    else{this.openInMobile=false;}
  }

}
