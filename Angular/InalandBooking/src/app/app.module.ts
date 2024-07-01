// src/app/app.module.ts
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
//import { RegisterComponent } from './register/register.component';
//import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
   // AppComponent,
   // HomeComponent,
  //  SearchComponent,
  //  AboutComponent,
  //  ContactComponent,
  //  RegisterComponent,
   // LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  //bootstrap: [AppComponent]
})
export class AppModule { }
