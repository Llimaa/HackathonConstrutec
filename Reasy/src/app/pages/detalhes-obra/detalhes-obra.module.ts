import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { DetalhesObraPage } from './detalhes-obra.page';
import { NavbarTabsComponentModule } from 'src/app/components/navbar-tabs/navbar-tabs.module';

const routes: Routes = [
  {
    path: '',
    component: DetalhesObraPage
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
  declarations: [DetalhesObraPage]
})
export class DetalhesObraPageModule { }
