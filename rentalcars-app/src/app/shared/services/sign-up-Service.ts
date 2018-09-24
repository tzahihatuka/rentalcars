import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Authorize } from "../models/Authorize-model";
import { signUpModel } from "../models/sign-up-model";
import { getLoginService } from "./login-servece";

//מאפשר לשירות הנוכחי להשתמש בתוכו בשירותים אחרים
@Injectable()
export class setNewUserService {
  a:any={isRagistared:this.myLogin.a.isRagistared}
    result:Authorize={ RoleNumber:""};
    constructor(private myHttpClient: HttpClient,private myLogin: getLoginService) {
    }
    
    signUp(userInfo:signUpModel) {
      let headers = new HttpHeaders({
        'Content-Type': 'application/json' });
    let options = { headers: headers };
       let apiUrl:string=`http://localhost:55860/api/User`;
      this.myHttpClient.post(apiUrl, userInfo,options,)
        .subscribe(
          res => {
            this.saveToLocatStorage(userInfo.UserName, userInfo.Password);
            location.replace("/Home");
          },
          err => {
            this.myLogin.a.isRagistared=false;
            localStorage.clear();
          }
        );
       
    }

    saveToLocatStorage(username: string, password: string){
        localStorage.setItem("username", username); 
        localStorage.setItem("password", password);
        localStorage.setItem("Authorize", "0");
        if(this.result.toString()!=null){
          this.myLogin.a.isRagistared=true;
          window.document.getElementById("Sclose").click();
      }
    }
    
}