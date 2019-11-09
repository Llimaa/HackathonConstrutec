import { Injectable } from '@angular/core';
import { Camera } from '@ionic-native/camera/ngx';
import { promise } from 'protractor';

@Injectable({
  providedIn: 'root'
})

export class UploadPhotoService {

  private pictureOptions: any;
  constructor
    (
      public camera: Camera,
  ) {

    this.pictureOptions = {
      quality: 100,
      targetWidth: 1024,
      targetHeight: 1024,
      correctOrientation: true,
      destinationType: this.camera.DestinationType.FILE_URI,
      encodingType: this.camera.EncodingType.PNG,
      mediaType: this.camera.MediaType.PICTURE,
      saveToPhotoAlbum: false,
      allowEdit: false,
    }
  }

  public async getPicture(): Promise<any> {
    this.camera.getPicture(this.pictureOptions).then((imageData) => {
      let base64Image = 'data:image/jpeg;base64,' + imageData;
      return base64Image;
    }, (err) => {
      console.error('erro ao carregar imagem: ', err);
    });
  }
}
