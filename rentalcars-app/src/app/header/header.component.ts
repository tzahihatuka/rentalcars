import { Component, OnInit } from '@angular/core';
import { getLoginService } from '../shared/services/login-servece';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isRagistared:any;
  userName:string;
  getfromLocalStor=[]
   RoleNumber:string;
  constructor(private myLogin: getLoginService) {
    this.RoleNumber=localStorage.getItem("Authorize");
    this.isRagistared=myLogin.a;
    if (localStorage.length > 1) {
      this.userName=localStorage.getItem("username");
    this.myLogin.a.isRagistared=true;
  this.isRagistared.isRagistared=true;
    }
  }



  closeMobileNavbar(){
  if(window.innerWidth<=991){
  document.getElementById("mobileShowNav").click();
  }
}

clearStorage(){
  this.RoleNumber="";
  localStorage.clear();
  this.myLogin.a.isRagistared=false;
  this.isRagistared.isRagistared=false;
  location.replace("/Home")
}

lestUrl:string;
relevanturl(url){
  this.lestUrl="";
  this.lestUrl=url;
}

  ngOnInit() {}

}
