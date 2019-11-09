import { Foto } from './../../models/foto';
import { Component, OnInit } from '@angular/core';
import { UploadPhotoService } from 'src/app/services/upload-photo-service/upload-photo-service';
import { Camera, CameraOptions } from '@ionic-native/camera/ngx';

@Component({
  selector: 'app-obra',
  templateUrl: './obra.page.html',
  styleUrls: ['./obra.page.scss'],
})
export class ObraPage implements OnInit {

  public foto: Foto;

  constructor(private readonly uploadPhotoService: UploadPhotoService, private camera: Camera) {
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
}
