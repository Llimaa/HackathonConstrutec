import { Comments } from './../../models/comment';
import { Address } from './../../models/address';
import { EStatusConstruction } from './../../enum/EStatusConstruction';
import { Report } from './../../models/report';
import { Component, OnInit } from '@angular/core';
import { Responsible } from 'src/app/models/responsible';
import { Construction } from 'src/app/models/construction';
import { Owner } from 'src/app/models/owner';
import { NavegacaoTool } from 'src/app/shared/navegacao/navegacao.tool';
import { ActivatedRoute, Router } from '@angular/router';
import { DETALHAR_OBRA, DETALHAR_RELATORIO, RELATORIO_URL } from '../page.constants';

@Component({
  selector: 'app-relatorios',
  templateUrl: './relatorios.page.html',
  styleUrls: ['./relatorios.page.scss'],
})
export class RelatoriosPage extends NavegacaoTool implements OnInit {

  public report: Report;
  public responsible: Responsible;
  public construction: Construction;
  public address: Address;
  public owner: Owner;
  public comments: Comments;

  public reports: Report[];
  //#region mock image
  public img = 'https://avrefrigeracao.com.br/wp-content/uploads/2018/09/Reforma-Constru%C3%A7%C3%A3o-Civil-1-2.jpg';
  public img2 = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTGY-RnM2iAU9pmRL4leihBsnEglH2oQBNZrYoBDJE6QNd3MunpPTSHOzbi0A&s=10';
  public img3 = 'https://s3.amazonaws.com/bc-portobello-archtrends-production/blog/wp-content/uploads/2017/07/04153724/projeto_engenharia-650x590.jpg';
  //#endregion

  constructor(
    protected route: ActivatedRoute,
    protected router: Router,
  ) {
    super(route, router);
    //#region mock
    this.reports = [];
    this.owner = new Owner('Abmael Araujo', '(94)992445585', 'abmaelaraujo@gmail.com', this.address);
    this.address = new Address('libano', 'eldorado', 2150);
    this.responsible = new Responsible('Marcos Lima', '0024463.37363', 'marcoslima@gmail.com', '(94)991285912');
    this.construction = new Construction('Casa Luxo', this.img2, EStatusConstruction.EmAndamento, [this.responsible], this.address, this.owner, new Date(), new Date());
    this.report = new Report('Relatório 01', this.img3, 'Este relatório e de uma obra, para construção de uma massao', this.responsible, this.construction, null, new Date());
    //#endregion
  }

  ngOnInit() {
    for (let index = 0; index <= 10; index++) {
      this.reports.push(this.report);
    }
  }

  async DetalharRelatorio() {
    let id = 1;

    this.irPara([DETALHAR_RELATORIO, id.toString()], this.reports[0], RELATORIO_URL);
  }

}
