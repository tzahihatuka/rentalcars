import { Component, OnInit } from '@angular/core';
import { lodinInfo } from '../shared/models/login-model';
import { getLoginService } from '../shared/services/login-servece';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  wrongDetails:boolean=false;
  lestUrl:string;
  isRagistared:any;
  constructor(private myLogin: getLoginService) {

  this.isRagistared=myLogin.a;
    this.lestUrl=document.location.pathname;
    let a=this.lestUrl.lastIndexOf("/")
     this.lestUrl=this.lestUrl.substring(0,a);
   }
  model: any = {};
  user:lodinInfo={userName:"",passWord:""};
  onSubmit()
{
  if(this.model.youremail==this.model.reenteremail){
 
    this.user.userName=this.model.UserName;
    this.user.passWord=this.model.password;
    this.myLogin.login(this.user.userName,this.user.passWord)
    if (!this.isRagistared.isRagistared) {
      this.wrongDetails=true;
    }
    else{
      this.wrongDetails=false;
    }
   
}
}

  ShowErrors:boolean=false;
  onFocus(event) {
    this.ShowErrors=true
  }
  ngOnInit() {
  }
  
}
