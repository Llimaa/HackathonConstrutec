import { Comments } from './../../models/comment';
import { Component, OnInit } from '@angular/core';
import { Report } from 'src/app/models/report';
import { Responsible } from 'src/app/models/responsible';
import { CreateRelatorioComponent } from '../create-relatorio/create-relatorio.component';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-rascunho-relatorio',
  templateUrl: './rascunho-relatorio.page.html',
  styleUrls: ['./rascunho-relatorio.page.scss'],
})
export class RascunhoRelatorioPage implements OnInit {

  public comments: Comments;

  public _comments: Comments[];

  constructor(public modalController: ModalController) {
    this._comments = [];
  }

  ngOnInit() {
    this.comments = new Comments();
    this.comments.Description = 'esta obra é uma obra de qualidade!!!';
    this.comments.Report = new Report();
    this.comments.Responsible = new Responsible();
    this.comments.Title = 'construção de uma casa';

    for (let index = 0; index < 2; index++) {
      this._comments.push(this.comments);
      console.log('coments: ', this._comments[0].Description);
    }
  }

  addComentario() {
    this._comments.push()
  }


  public async addRelatorio() {
    const modal = await this.modalController.create({
      component: CreateRelatorioComponent,
      componentProps: {}
    });

    modal.onDidDismiss()
      .then((value: any) => {
      });
    return await modal.present();
  }
}
