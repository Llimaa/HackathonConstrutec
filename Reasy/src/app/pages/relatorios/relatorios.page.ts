import { Comments } from './../../models/comment';
import { Address } from './../../models/address';
import { EStatusConstruction } from './../../enum/EStatusConstruction';
import { Report } from './../../models/report';
import { Component, OnInit } from '@angular/core';
import { Responsible } from 'src/app/models/responsible';
import { Construction } from 'src/app/models/construction';
import { Owner } from 'src/app/models/owner';

@Component({
  selector: 'app-relatorios',
  templateUrl: './relatorios.page.html',
  styleUrls: ['./relatorios.page.scss'],
})
export class RelatoriosPage implements OnInit {

  public report: Report;
  public responsible: Responsible;
  public construction: Construction;
  public address: Address;
  public owner: Owner;
  public comments: Comments;

  public reports: Report[];

  public img = 'https://avrefrigeracao.com.br/wp-content/uploads/2018/09/Reforma-Constru%C3%A7%C3%A3o-Civil-1-2.jpg';
  public img2 = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTGY-RnM2iAU9pmRL4leihBsnEglH2oQBNZrYoBDJE6QNd3MunpPTSHOzbi0A&s=10';
  public img3 = 'https://dngqrog6k9y1f.cloudfront.net/media/catalog/product/cache/1/image/363x/040ec09b1e35df139433887a97daa66f/i/c/icones_350-x-350_px_final_09.png';

  constructor() {
    this.reports = [];
    this.owner = new Owner('Abmael Araujo', '(94)992445585', 'abmaelaraujo@gmail.com', this.address);
    this.address = new Address('libano', 'eldorado', 2150);
    this.responsible = new Responsible('Marcos Lima', '0024463.37363', 'marcoslima@gmail.com', '(94)991285912');
    this.construction = new Construction('Casa Luxo', this.img2, EStatusConstruction.EmAndamento, [this.responsible], this.address, this.owner, new Date(), new Date());
    this.report = new Report('Relato´rio 01', this.img3, 'Este relatorio e de uma obra, para construção de uma massao', this.responsible, this.construction, null, new Date());
  }

  ngOnInit() {
    for (let index = 0; index <= 10; index++) {
      this.reports.push(this.report);
    }
    console.log('this.reports: ', this.reports);
  }

}
