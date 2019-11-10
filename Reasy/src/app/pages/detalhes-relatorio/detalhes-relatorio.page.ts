import { Component, OnInit } from '@angular/core';
import { NavegacaoTool } from 'src/app/shared/navegacao/navegacao.tool';
import { Router, ActivatedRoute } from '@angular/router';
import { RELATORIO_URL } from '../page.constants';
import { ModalController } from '@ionic/angular';
import { ComentariosPage } from '../comentarios/comentarios.page';

@Component({
  selector: 'app-detalhes-relatorio',
  templateUrl: './detalhes-relatorio.page.html',
  styleUrls: ['./detalhes-relatorio.page.scss'],
})
export class DetalhesRelatorioPage extends NavegacaoTool implements OnInit {

  public item: any = [];

  constructor(
    protected route: ActivatedRoute,
    protected router: Router,
    public modalController: ModalController
  ) {
    super(route, router);
  }

  ngOnInit() {
    this.item = this.buscarParametros();
    console.log('this.item: ', this.item);
  }

  async voltar() {
    this.irPara([RELATORIO_URL]);
  }

  public async openComentarios() {
    const modal = await this.modalController.create({
      component: ComentariosPage,
      componentProps: {}
    });

    modal.onDidDismiss()
      .then((value: any) => {
      });
    return await modal.present();
  }

}
