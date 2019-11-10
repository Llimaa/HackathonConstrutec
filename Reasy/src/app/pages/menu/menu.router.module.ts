import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuPage } from './menu.page';
import { OBRA_URL } from '../page.constants';

const routes: Routes = [
  {
    path: '', redirectTo: OBRA_URL, pathMatch: 'full'
  },
  {
    path: 'menu',
    component: MenuPage,
    children: [
      {
        path: '',
        loadChildren: '../tabs/tabs.module#TabsPageModule'
      },
      {
        path: 'obra',
        loadChildren: '../obra/obra.module#ObraPageModule'
      },
      {
        path: 'detalhes-obra/:id',
        loadChildren: '../detalhes-obra/detalhes-obra.module#DetalhesObraPageModule'
      }, {
        path: 'comentarios',
        loadChildren: '../comentarios/comentarios.module#ComentariosPageModule'
      }, {
        path: 'detalhes-relatorio/:id',
        loadChildren: '../detalhes-relatorio/detalhes-relatorio.module#DetalhesRelatorioPageModule'
      },
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],

  exports: [
    RouterModule
  ]
})
export class MenuPageRoutingModule { }
