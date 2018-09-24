import { Component} from '@angular/core';
import { carsModel } from '../shared/services/car-model-Service';

@Component({
  selector: 'editingvehicletypes',
  templateUrl: './editingvehicletypes.component.html',
  styleUrls: ['./editingvehicletypes.component.css']
})
export class EditingvehicletypesComponent  {
  model:any={a:""};
  carGallery:any={a:""};
  constructor(private myCarModel:carsModel) {
    this.myCarModel.getCarTyps();
    this.carGallery=this.myCarModel.TypeName;
  }
  TypsModel:any={a:""};
  search(){
    this.myCarModel.getListCarTypsModel(this.model.ManufacturerName).subscribe((x: any) => {this.TypsModel.a=x});
  }
  arr:Array<any>=[];
  setItem(order){
    this.model.ManufacturerName = order.ManufacturerName,
    this.model.Model = order.Model,
    this.model.DailyCost = order.DailyCost,
    this.model.CostDayOverdue = order.CostDayOverdue,
    this.model.ManufactureYear = order.ManufactureYear,
    this.model.Gear = order.Gear;
    this.TypsModel.a=[order];
    this.arr.push(order);
  }
   
  Add(){
  this.myCarModel.addnewType(this.model);
  setTimeout(() => {
    this.search()
  },1000 );
 }
 Update(){
  
  this.arr.push(this.model)
  this.myCarModel.UpdatenewType(this.arr);
  setTimeout(() => {
    this.search()
  },1000 );
 }
 delete(){
  this.myCarModel.deleteCarType(this.model);
  setTimeout(() => {
    this.search()
  },1000 );
 }



}