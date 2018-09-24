
export interface carModel {
   a:{ Gear:string,
    ManufacturerName:string,
    ManufactureYear:Date,
    Model?:string,
    DailyCost?:number,
    CostDayOverdue?:number,
    BranchesName:string,
    UpdatedMileage:number,
    IsProperForRent:boolean,
    VehicleNumber:number,
    VehiclePic:string
   }
}