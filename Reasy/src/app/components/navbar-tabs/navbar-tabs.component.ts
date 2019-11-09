import { Component, Input } from '@angular/core';
import { MenuController } from '@ionic/angular';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'component-navbar-tabs',
  templateUrl: './navbar-tabs.component.html',
  styleUrls: ['./navbar-tabs.component.scss'],
})

export class NavbarTabsComponent {

  @Input() title?: string;
  @Input() backTo?: string;

  public valor: boolean;
  public closeSearch: boolean;

  constructor
    (
      protected route: ActivatedRoute,
      protected router: Router,
      public menuCtrl: MenuController
    ) {

    this.closeSearch = true;
  }

  async openMenu() {
    console.log(window);
    this.menuCtrl.toggle('start');
    await this.menuCtrl.enable(false, 'end');
  }
}
