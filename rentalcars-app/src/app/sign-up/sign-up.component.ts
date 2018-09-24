import { Component, OnInit, Input } from '@angular/core';
import { NgbDateStruct, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap/datepicker/ngb-date';
import { signUpModel } from '../shared/models/sign-up-model';
import { setNewUserService } from '../shared/services/sign-up-Service';

@Component({
  selector: 'sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  date=new Date();
  year=this.date.getFullYear()- 18;
  month=this.date.getMonth()+1;
  day=this.date.getDate();
  lestUrl:string;
  isRagistared:any;
  constructor(calendar: NgbCalendar,private mySignup: setNewUserService ) {
    
    this.isRagistared=mySignup.a;
    this.lestUrl=document.location.pathname;
    let a=this.lestUrl.lastIndexOf("/")
     this.lestUrl=this.lestUrl.substring(0,a);
    this.date=new Date();
    this.year=this.date.getFullYear()- 18;
    this.month=this.date.getMonth()+1;
    this.day=this.date.getDate();
    this.maxDate = {
      "year": this.year,
      "month": this.month,
      "day": this.day
    };

    this.minDate = {
      "year": this.date.getFullYear()- 100,
      "month": this.month,
      "day": this.day
    };
   }
   
  hoveredDate: NgbDate;

  fromDate: NgbDate;
  toDate: NgbDate;
  public minDate: NgbDateStruct ; 
  public maxDate: NgbDateStruct ; 
  model: any = {};
  userInfo:signUpModel={ 
     FullUserName:"",
    UserIdNumber:"",
    UserName:"",
    Password:"",
    BirthDay:new Date(2000+"-"+1+"-"+1),
    Sex:true,
    Email:""
  };
  
  onSubmit()
{
  var maleOrfemale=this.model.sex=="male"?true:false;
  
   this.userInfo.FullUserName=this.model.fullname;
   this.userInfo.UserName=this.model.UserName;
   this.userInfo.UserIdNumber=this.model.IdNamber;
   this.userInfo.BirthDay=new Date(this.model.DateOfBirth.year+"-"+(this.model.DateOfBirth.month)+"-"+(this.model.DateOfBirth.day+1));
   this.userInfo.Email=this.model.youremail;
   this.userInfo.Password=this.model.password;
   this.userInfo.Sex=maleOrfemale;

this.mySignup.signUp(this.userInfo);
}

ShowErrors:boolean=false;
onFocus() {
  this.ShowErrors=true
}

  ngOnInit() {
 
  }

}
