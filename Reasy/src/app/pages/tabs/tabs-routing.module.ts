import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TabsPage } from './tabs.page';

const routes: Routes = [
  {
    path: 'tabs',
    component: TabsPage,
    children: [
      {
        path: 'obra',
        children: [
          {
            path: '',
            loadChildren: () =>
              import('../obra/obra.module').then(m => m.ObraPageModule)
          }
        ]
      },
      {
        path: 'rascunho',
        children: [
          {
            path: '',
            loadChildren: () =>
              import('../rascunho-relatorio/rascunho-relatorio.module').then(m => m.RascunhoRelatorioPageModule)
          }
        ]
      },

      {
        path: 'relatorios',
        children: [
          {
            path: '',
            loadChildren: () =>
              import('../relatorios/relatorios.module').then(m => m.RelatoriosPageModule)
          }
        ]
      },
      {
        path: '',
        redirectTo: '/tabs/obra',
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '',
    redirectTo: '/tabs/obra',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TabsPageRoutingModule { }
