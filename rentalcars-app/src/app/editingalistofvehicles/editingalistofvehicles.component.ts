import { Component, OnInit } from '@angular/core';
import { carsModel } from '../shared/services/car-model-Service';
import { carsService } from '../shared/services/cars-Service';
import { branchservice } from '../shared/services/branch-Service';
import { UploadImageService } from '../shared/services/upload-image.service';

@Component({
  selector: 'editingalistofvehicles',
  templateUrl: './editingalistofvehicles.component.html',
  styleUrls: ['./editingalistofvehicles.component.css']
})
export class EditingalistofvehiclesComponent {
  model:any={a:""};

  carGallery:any={a:""};
  TypsModel:any={a:""};
  TypsGetGear:any={a:""};
  TypsGetYear:any={a:Date};
  carInfo:any={a:""};
  Branchs:any={a:""}
  selectedCar:boolean=false;
  
  constructor(private myCar:carsService,private myCarModel:carsModel,private myBranchs:branchservice,private imageService: UploadImageService ) {
  this.myCarModel.getCarTyps();
  this.myBranchs.getBraenchList();
  this.myBranchs=this.myBranchs.branchList
    this.carGallery=this.myCarModel.TypeName;
    this.TypsModel=this.myCarModel.TypsModel;
this.TypsGetGear=this.myCarModel.TypsGetGear;
this.TypsGetYear=this.myCarModel.TypsGetYear;
this.carInfo=myCar.carInfo;

   }
  
   Company:string;

saverange(){
  this.myCarModel.getCarTypsModel(this.Company);
  this.model.ManufacturerName=this.Company;
  this.model.IsProperForRent=true;
}

search(){
  this.selectedCar=true;
  this.myCar.getCarByNumber(this.model.VehicleNumber);
}
appdateArray:Array<any>=[];
setItem(order){
  let c= document.getElementsByTagName("td");
  for (var i=0; i<c.length; i++) {
    c[i].style.color ="blue";
  }
  this.appdateArray.push(order);
}

imageUrl: string = "";
  fileToUpload: File = null;

  handleFileInput(file: FileList) {
    //Save image to the class property
    this.fileToUpload = file.item(0);


    //Show image preview
    let reader = new FileReader();
    reader.onload = (event: any) => { this.imageUrl = event.target.result; }
    reader.readAsDataURL(this.fileToUpload);
  }

  OnSubmit() {
if(this.fileToUpload.name!=null){
    this.imageService.postFile(this.fileToUpload.name, this.fileToUpload)
   .subscribe(data => { this.model.VehiclePic=data.toString()});
}
  }

 
  Update(){
   
    if(this.model.VehiclePic!=null){
    this.appdateArray.push(this.model);
    this.myCar.updateanCar(this.appdateArray);
    this.appdateArray=[];
  }
  }
carUploded:boolean=false;
  Add(){
    if(this.model.VehiclePic!=null){
    this.myCar.addNewCar(this.model);
    }
    setTimeout(() => {
    this.carUploded= this.myCar.uplodedCar;
    }, 2000);
    }

    delete(){
      this.myCar.deletecar(this.model.VehicleNumber);
    }
}


