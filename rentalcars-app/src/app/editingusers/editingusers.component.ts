import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user-Service';
import { MaxLengthValidator } from '../../../node_modules/@angular/forms';
import { UploadImageService } from '../shared/services/upload-image.service';
import { getQueryPredicate } from '../../../node_modules/@angular/compiler/src/render3/view/util';

@Component({
  selector: 'editingusers',
  templateUrl: './editingusers.component.html',
  styleUrls: ['./editingusers.component.css']
})
export class EditingusersComponent implements OnInit {
  usersList:any={a:""};
  model:any={a:""};
  Sex:Array<string>=["male","female"]
UserRole:Array<string>=["admin","worker","castomer"]
  constructor(private myUsersService:UserService,private imageService: UploadImageService ) {
    this.model.UserRole="admin";
    this.model.Sex="male";
   }
   userAdded:boolean=true;
  ShowAllUsers(){
  this.myUsersService.getallusers().subscribe((res)=>{ this.usersList.a=res},err => {
    });
  }
  SearchUser(){
    this.myUsersService.getalluserById(this.model.UserIDNumber).subscribe((res)=>{ this.usersList.a=[res]},err => {
    });
  }
users:any={a:""};
arr:Array<any>;


  setItem(user){
    this.arr=[];
    this.model.FullUserName = user.FullUserName,
    this.model.UserName = user.UserName,
    this.model.Password = user.Password,
    this.model.BirthDay = user.BirthDay,
    this.model.Sex = user.Sex,
    this.model.UserPic =user.UserPic;
    this.model.Email = user.Email,
    this.model.UserRole = user.UserRole,
    this.model.UserIdNumber = user.UserIdNumber,
    this.usersList.a=[user];
    this.arr.push(user);
  }
  getPic(fullPic:String){
    var parts = fullPic.split('/');
var lastSegment = parts.pop() || parts.pop(); 
return lastSegment;
  }
Add(){
  this.myUsersService.AddNewUser(this.model).subscribe(
    res => {
      this.userAdded=true;
      this.result=res.toString();
    },
    err => {
      this.userAdded=false;
    }
  );
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
  upLoudPic() {
  if(this.fileToUpload.name!=null){
      this.imageService.postFile(this.fileToUpload.name, this.fileToUpload)
     .subscribe(data => { this.model.UserPic=data.toString()});
  }
    }
    Update(){
      let a=this.model.UserPic;
      this.model.UserPic=this.getPic(this.model.UserPic);
      this.arr.push(this.model);
      this.myUsersService.UpdateUser(this.arr).subscribe(
        res => {
          this.model.UserPic=a; 
          this.usersList.a=[this.model];
          this.result=res.toString();
            },
            err => {
            
            }
      );
    }
    result:string;
    delete(){
    this.myUsersService.deleteUser(this.model.UserIdNumber).subscribe(
        res => {
          this.result=res.toString();
          this.ShowAllUsers();
        },
        err => {
        
        }
      );
    }

  ngOnInit() {
  }

}
