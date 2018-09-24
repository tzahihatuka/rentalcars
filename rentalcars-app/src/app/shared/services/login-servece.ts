import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { lodinInfo } from "../models/login-model";
import { Authorize } from "../models/Authorize-model";
import { signUpModel } from "../models/sign-up-model";

//מאפשר לשירות הנוכחי להשתמש בתוכו בשירותים אחרים
@Injectable()
export class getLoginService {
   a:any={isRagistared:false}
    result:Authorize={ RoleNumber:""};
    constructor(private myHttpClient: HttpClient) {}
    
    login(username: string, password: string) {
     

       let apiUrl:string=`http://localhost:55860/api/User`;
      this.myHttpClient.get(apiUrl,
        {
            headers: new HttpHeaders().set('Authorization', username+" "+password)
       }).subscribe((res:Authorize)=>{ this.result=res, this.saveToLocatStorage(username,password)},err => {
        this.a.isRagistared=false;
        localStorage.clear();
      });
     
    }

    saveToLocatStorage(username: string, password: string){
        localStorage.setItem("username", username); 
        localStorage.setItem("password", password);
        localStorage.setItem("Authorize", this.result.toString());
        if(this.result.toString()!=null){
            this.a.isRagistared=true;
            window.document.getElementById("close").click();
            location.reload();
        }
    }


    getUser(userIdNumber:string) {
       let username=localStorage.getItem("username");
       let password=localStorage.getItem("password");

       let apiUrl:string=`http://localhost:55860/api/User/${userIdNumber}`;

       this.myHttpClient.get(apiUrl,
         {
             headers: new HttpHeaders().set('Authorization', username+" "+password)
        }).subscribe((res:signUpModel)=>{ console.log(res) });
    }
    
}

