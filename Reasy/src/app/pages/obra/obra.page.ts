import { Foto } from './../../models/foto';
import { Component, OnInit } from '@angular/core';
import { UploadPhotoService } from 'src/app/services/upload-photo-service/upload-photo-service';
import { Camera, CameraOptions } from '@ionic-native/camera/ngx';
import { Obra } from 'src/app/models/obra';
import { DETALHAR_OBRA, OBRA_URL } from '../page.constants';
import { NavegacaoTool } from 'src/app/shared/navegacao/navegacao.tool';
import { ActivatedRoute, Router } from '@angular/router';
import { Endereco } from 'src/app/models/endereco';
import { Proprietario } from 'src/app/models/proprietario';
import { Responsavel } from 'src/app/models/responsavel';
import { EStatusObra } from 'src/app/enum/EStatusObra';

@Component({
  selector: 'app-obra',
  templateUrl: './obra.page.html',
  styleUrls: ['./obra.page.scss'],
})
export class ObraPage extends NavegacaoTool implements OnInit {

  public foto: Foto;


  public obras: Obra[];
  public status: string;

  private obra: Obra;
  private endereco: any;
  private proprietario: any;
  private responsavel: any;


  constructor(
    private readonly uploadPhotoService: UploadPhotoService,
    private camera: Camera,
    protected route: ActivatedRoute,
    protected router: Router,

  ) {
    super(route, router);
    this.foto = new Foto();
    this.obra = new Obra();

    this.obras = [];
    const _obra = new Obra('Predio A', new Foto('foto', null, null), EStatusObra.EmAndamento)
    this.endereco = new Endereco('libano', 'eldorado', 2150);
    this.proprietario = new Proprietario('marcos', '(94) 991285912', 'teste');
    this.responsavel = new Responsavel('marcos', '11009.222.4444-33', 'crea@gmail.com', '(94) 991294433', [_obra]);

  }

  ngOnInit() {


    this.obra.nome = 'Construtec';
    this.obra.Imagem = new Foto('https://avrefrigeracao.com.br/wp-content/uploads/2018/09/Reforma-Constru%C3%A7%C3%A3o-Civil-1-2.jpg', null, null);
    this.obra.statusObra = EStatusObra.Iniciado;
    this.obra.endereco = this.endereco;
    this.obra.proprietario = this.proprietario;
    this.obra.Residente = this.proprietario;
    this.obra.Fiscal1 = this.responsavel;
    this.obra.Fiscal2 = this.responsavel;
    this.obra.Relatorio = this.responsavel;
    this.obra.dataInicio = new Date();
    this.obra.dataFinal = new Date();

    for (let index = 0; index < 10; index++) {
      this.obras.push(this.obra);
      switch (this.obras[index].statusObra) {
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
    console.log('this.obra: ', this.obras);
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

    this.irPara([DETALHAR_OBRA, id.toString()], OBRA_URL);
  }
}
