import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';
import { NavbarTabsComponent } from './navbar-tabs.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule
  ],

  declarations: [
    NavbarTabsComponent
  ],

  exports: [
    NavbarTabsComponent
  ],

  providers: [
  ]
})
export class NavbarTabsComponentModule { }
