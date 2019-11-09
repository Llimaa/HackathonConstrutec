import { Component } from '@angular/core';
import { MenuController, NavController, ModalController } from '@ionic/angular';
import { ActivatedRoute, Router } from '@angular/router';
import { PAGES } from '../page.constants';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.page.html',
  styleUrls: ['./menu.page.scss'],
})

export class MenuPage {

  pages = PAGES;


  constructor
    (
      private menuCtrl: MenuController,
      private navController: NavController,
      private modalController: ModalController,
      protected route: ActivatedRoute,
      protected router: Router,
  ) {
  }

  ngOnInit() { }

  ionViewWillEnter() { }
}
