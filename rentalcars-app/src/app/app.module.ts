import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './footer/footer.component';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { CarsComponent } from './cars/cars.component';
import { SearchoptionsComponent } from './searchoptions/searchoptions.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HomeComponent } from './home/home.component';
import { SelectedCarComponent } from './selected-car/selected-car.component';
import { getLoginService } from './shared/services/login-servece';
import { setNewUserService } from './shared/services/sign-up-Service';
import { CarGalleryComponent } from './car-gallery/car-gallery.component';
import { carsService } from './shared/services/cars-Service';
import { filterCarsService } from './shared/services/filterCar-Service';
import { carsModel } from './shared/services/car-model-Service';
import { CarPriceComponent } from './car-price/car-price.component';
import { CarOrderService } from './shared/services/order-Service';
import { MyOrdersComponent } from './my-orders/my-orders.component';
import { OrderPreviewComponent } from './order-preview/order-preview.component';
import { ReturnCarComponent } from './return-car/return-car.component';
import { UnReturnedCarsComponent } from './un-returned-cars/un-returned-cars.component';
import { EditOrdersComponent } from './edit-orders/edit-orders.component';
import { EditingalistofvehiclesComponent } from './editingalistofvehicles/editingalistofvehicles.component';
import { EditingusersComponent } from './editingusers/editingusers.component';
import { EditingvehicletypesComponent } from './editingvehicletypes/editingvehicletypes.component';
import { branchservice } from './shared/services/branch-Service';
import { UploadImageService } from './shared/services/upload-image.service';
import { UserService } from './shared/services/user-Service';


const appRoutes: Routes = [
  { path: 'EditOrders',component: EditOrdersComponent },
  { path: 'Editingalistofvehicles',component: EditingalistofvehiclesComponent },
  { path: 'Editingusers',component: EditingusersComponent },
  { path: 'Editingvehicletypes',component: EditingvehicletypesComponent },

  { path: 'login',component: LoginComponent },
  { path: 'signup',component: SignUpComponent },
  {path: 'cars',component: CarsComponent },
  { path: 'Home',component: HomeComponent },
  {path: 'cars/signup',component: SignUpComponent },
  { path: 'Home/signup',component: SignUpComponent },
  { path: 'Home/login',component: LoginComponent },
  {path: 'cars/login',component: LoginComponent },
  {path: 'cars/Order',component: SelectedCarComponent },
  {
    path: "return-car", component: ReturnCarComponent,
    children: [
       { path: '', redirectTo: '/return-car', pathMatch: 'full' },
        { path: 'un-returned-cars/:selectedOrder', component: UnReturnedCarsComponent },
       
        { path: '**',redirectTo: '/return-car',pathMatch: 'full'},
    ]
},
  {
    path: "MyOrders", component: MyOrdersComponent,
    children: [
       { path: '', redirectTo: '/MyOrders', pathMatch: 'full' },
        { path: 'carOrder/:selectedOrder', component: OrderPreviewComponent },
       
        { path: '**',redirectTo: '/MyOrders',pathMatch: 'full'},
    ]
},
{ path: '',redirectTo: '/Home',pathMatch: 'full'},
{ path: '**', component: PageNotFoundComponent },
];


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainComponent,
    FooterComponent,
    LoginComponent,
    SignUpComponent,
    CarsComponent,
    SearchoptionsComponent,
    PageNotFoundComponent,
    HomeComponent,
    SelectedCarComponent,
    CarGalleryComponent,
    CarPriceComponent,
    MyOrdersComponent,
    OrderPreviewComponent,
    ReturnCarComponent,
    UnReturnedCarsComponent,
    EditOrdersComponent,
    EditingalistofvehiclesComponent,
    EditingusersComponent,
    EditingvehicletypesComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    NgbModule.forRoot(),
    RouterModule.forRoot(appRoutes),
      FormsModule,
      ReactiveFormsModule
  ],
  providers: [getLoginService,
    setNewUserService,carsService,
    filterCarsService,carsModel,
    CarOrderService,branchservice,
    UploadImageService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
