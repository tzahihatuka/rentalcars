import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService{
constructor(private myHttpClient:HttpClient){
}
getallusers(){
    let apiUrl:string=`http://localhost:55860/api/GetAllusers`;
   return this.myHttpClient.get(apiUrl,
      {
          headers: new HttpHeaders().set('Authorization',  localStorage.getItem("username")+" "+localStorage.getItem("password"))
     })
}
getalluserById(userNumber){
    let apiUrl:string=`http://localhost:55860/api/GetuserById?userNumber=${userNumber}`;
   return this.myHttpClient.get(apiUrl,
      {
          headers: new HttpHeaders().set('Authorization',  localStorage.getItem("username")+" "+localStorage.getItem("password"))
     })
}

AddNewUser(userInfo:any) {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
  let options = { headers: headers };
     let apiUrl:string=`http://localhost:55860/api/AddingusersByAdmin`;
  return  this.myHttpClient.post(apiUrl, userInfo,options,)
  }


UpdateUser(updateUser:Array<any>){
    let apiUrl:string=`http://localhost:55860/api/User`;
        let headers = new HttpHeaders({
          'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
      let options = { headers: headers };
      return this.myHttpClient.put<any>(apiUrl, updateUser, options)
          
}

deleteUser(deleteUser:string){
    let apiUrl:string=`http://localhost:55860/api/User?UserIdNumber=${deleteUser}`;
    let headers = new HttpHeaders({
      'Content-Type': 'application/json' }).set('Authorization', localStorage.getItem("username")+" "+localStorage.getItem("password"));
  let options = { headers: headers };
return  this.myHttpClient.delete(apiUrl,options)
 }
}