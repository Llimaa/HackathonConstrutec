import { Owner } from './../../models/owner';
import { Address } from './../../models/address';
import { EStatusConstruction } from './../../enum/EStatusConstruction';
import { Foto } from './../../models/foto';
import { Component, OnInit } from '@angular/core';
import { UploadPhotoService } from 'src/app/services/upload-photo-service/upload-photo-service';
import { Camera, CameraOptions } from '@ionic-native/camera/ngx';
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

  public foto: Foto;


  public constructions: Construction[];
  public status: string;

  private construction: Construction;
  private address: any;
  private owner: any;//proprietario
  private responsible: any;


  constructor(
    private readonly uploadPhotoService: UploadPhotoService,
    private camera: Camera,
    protected route: ActivatedRoute,
    protected router: Router,

  ) {
    super(route, router);
    this.foto = new Foto();
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

  public getPhoto() {
    this.uploadPhotoService.getPicture().then(res => {
      this.foto.data = res;
    });
  }

  public getPhoto2() {
    const options: CameraOptions = {
      quality: 100,
      destinationType: this.camera.DestinationType.FILE_URI,
      encodingType: this.camera.EncodingType.JPEG,
      mediaType: this.camera.MediaType.PICTURE
    }

    this.camera.getPicture(options).then((imageData) => {
      // imageData is either a base64 encoded string or a file URI
      // If it's base64 (DATA_URL):
      let base64Image = 'data:image/jpeg;base64,' + imageData;
      this.foto.data = base64Image;
    }, (err) => {
      // Handle error
    });
  }

  async detalharObra() {
    let id = 1;

    this.irPara([DETALHAR_OBRA, id.toString()], this.construction, OBRA_URL);
  }
}
