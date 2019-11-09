import { Component, Input, OnInit } from '@angular/core';
import { MenuController } from '@ionic/angular';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'component-navbar-tabs',
  templateUrl: './navbar-tabs.component.html',
  styleUrls: ['./navbar-tabs.component.scss'],
})

export class NavbarTabsComponent implements OnInit {

  @Input() title?: string;
  @Input() backTo?: string;

  public path: string;
  public valor: boolean;
  public isDetail: boolean;
  public closeSearch: boolean;

  constructor
    (
      protected route: ActivatedRoute,
      protected router: Router,
      public menuCtrl: MenuController
    ) {
    this.isDetail = false;
    this.closeSearch = true;
  }

  ngOnInit() {
    console.log('this.backTo.length: ', this.backTo.length);
    if (this.backTo.length > 1) {
      this.isDetail = true;
      this.path = this.backTo;
    }
  }

  async openMenu() {
    console.log(window);
    this.menuCtrl.toggle('start');
    await this.menuCtrl.enable(false, 'end');
  }
}
