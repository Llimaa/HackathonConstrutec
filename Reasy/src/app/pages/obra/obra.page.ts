import { Foto } from './../../models/foto';
import { Component, OnInit } from '@angular/core';
import { UploadPhotoService } from 'src/app/services/upload-photo-service/upload-photo-service';
import { Camera, CameraOptions } from '@ionic-native/camera/ngx';
import { Obra } from 'src/app/models/obra';
import { DETALHAR_OBRA, OBRA_URL } from '../page.constants';
import { NavegacaoTool } from 'src/app/shared/navegacao/navegacao.tool';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-obra',
  templateUrl: './obra.page.html',
  styleUrls: ['./obra.page.scss'],
})
export class ObraPage extends NavegacaoTool implements OnInit {

  public foto: Foto;

  constructor(
    private readonly uploadPhotoService: UploadPhotoService,
    private camera: Camera,
    protected route: ActivatedRoute,
    protected router: Router,
  ) {
    super(route, router);
    this.foto = new Foto();
  }

  ngOnInit() {
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
