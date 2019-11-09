import { NavegacaoTool } from 'src/app/shared/navegacao/navegacao.tool';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-detalhes-obra',
  templateUrl: './detalhes-obra.page.html',
  styleUrls: ['./detalhes-obra.page.scss'],
})
export class DetalhesObraPage extends NavegacaoTool implements OnInit {

  public item: any = [];

  constructor(
    protected route: ActivatedRoute,
    protected router: Router,
  ) {
    super(route, router);
  }

  ngOnInit() {

    this.item = this.buscarParametros();
    console.log('this.item: ', this.item);  
  }
}
