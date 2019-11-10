import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { RascunhoRelatorioPage } from './rascunho-relatorio.page';
import { NavbarTabsComponentModule } from 'src/app/components/navbar-tabs/navbar-tabs.module';
import { CreateRelatorioComponentModule } from '../create-relatorio/create-relatorio.component.module';

const routes: Routes = [
  {
    path: '',
    component: RascunhoRelatorioPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes),
    NavbarTabsComponentModule,
    CreateRelatorioComponentModule
  ],
  declarations: [RascunhoRelatorioPage]
})
export class RascunhoRelatorioPageModule { }
