import { Data } from "@angular/router";


export interface carOrder {a:{
      StartDate?:Date,
      ReturnDate?:Date,
      UserName:string,
      VehicleNumber:number,
      ActualReturnDate?:Data
}
}