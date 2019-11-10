import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { RelatoriosPage } from './relatorios.page';
import { NavbarTabsComponentModule } from 'src/app/components/navbar-tabs/navbar-tabs.module';

const routes: Routes = [
  {
    path: '',
    component: RelatoriosPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes),
    NavbarTabsComponentModule
  ],
  declarations: [RelatoriosPage]
})
export class RelatoriosPageModule { }
