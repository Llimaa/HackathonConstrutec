import { Owner } from './../../models/owner';
import { Address } from './../../models/address';
import { EStatusConstruction } from './../../enum/EStatusConstruction';
import { Component, OnInit } from '@angular/core';
import { UploadPhotoService } from 'src/app/services/upload-photo-service/upload-photo-service';
import { DETALHAR_OBRA, OBRA_URL } from '../page.constants';
import { NavegacaoTool } from 'src/app/shared/navegacao/navegacao.tool';
import { ActivatedRoute, Router } from '@angular/router';
import { Construction } from 'src/app/models/construction';
import { Responsible } from 'src/app/models/responsible';

@Component({
  selector: 'app-obra',
  templateUrl: './obra.page.html',
  styleUrls: ['./obra.page.scss'],
})
export class ObraPage extends NavegacaoTool implements OnInit {

  public constructions: Construction[];
  public status: string;

  private construction: Construction;
  private address: any;
  private owner: any;//proprietario
  private responsible: any;


  constructor(
    private readonly uploadPhotoService: UploadPhotoService,
    protected route: ActivatedRoute,
    protected router: Router,

  ) {
    super(route, router);
    this.construction = new Construction();

    this.constructions = [];
    const construction = new Construction('Predio A', 'foto', EStatusConstruction.EmAndamento)
    this.address = new Address('libano', 'eldorado', 2150);
    this.owner = new Owner('marcos', '(94) 991285912', 'teste');
    this.responsible = new Responsible('marcos', '11009.222.4444-33', 'crea@gmail.com', '(94) 991294433');

  }

  ngOnInit() {


    this.construction.Name = 'Construtec';
    this.construction.Image = 'https://avrefrigeracao.com.br/wp-content/uploads/2018/09/Reforma-Constru%C3%A7%C3%A3o-Civil-1-2.jpg';
    this.construction.sStatusConstruction = EStatusConstruction.Iniciado;
    this.construction.owner = this.owner;
    this.construction.responsibles = this.responsible;
    this.construction.address = this.address;
    this.construction.StartDate = new Date();
    this.construction.FinalDate = new Date();

    for (let index = 0; index < 10; index++) {
      this.constructions.push(this.construction);
      switch (this.constructions[index].sStatusConstruction) {
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

    }
    console.log('this.obra: ', this.construction);
  }



  async detalharObra() {
    let id = 1;

    this.irPara([DETALHAR_OBRA, id.toString()], this.construction, OBRA_URL);
  }
}
