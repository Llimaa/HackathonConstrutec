import { NavegacaoTool } from 'src/app/shared/navegacao/navegacao.tool';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DETALHAR_OBRA, OBRA_URL, RELATORIO_URL } from '../page.constants';

@Component({
  selector: 'app-detalhes-obra',
  templateUrl: './detalhes-obra.page.html',
  styleUrls: ['./detalhes-obra.page.scss'],
})
export class DetalhesObraPage extends NavegacaoTool implements OnInit {

  public item: any = [];
  public status: string;

  constructor(
    protected route: ActivatedRoute,
    protected router: Router,
  ) {
    super(route, router);
  }

  ngOnInit() {
    this.item = this.buscarParametros();

    switch (this.item.sStatusConstruction) {
      case 0:
        this.status = 'Iniciada'
        break;

      case 1:
        this.status = 'Em andamento'
        break;

      case 2:
        this.status = 'Finalizada'
        break;
      case 3:
        this.status = 'Atrasado'
        break;
    }

    console.log('this.item: ', this.item);

  }

  async voltar() {
    this.irPara([OBRA_URL]);
  }

  async verRelatorios() {
    this.irPara([RELATORIO_URL]);
  }

  // showPhotoViewer() {
  //   this.photoViewer.show(ImageViewController.getUrlFoto(this.evento));
  // }
}
