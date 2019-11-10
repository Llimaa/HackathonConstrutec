import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { Camera, CameraOptions } from '@ionic-native/camera/ngx';
import { Foto } from 'src/app/models/foto';
import { EventsService } from 'src/app/services/events.-providers.service';

@Component({
    selector: 'component-create-relatorio',
    templateUrl: 'create-relatorio.component.html',
    styleUrls: ['create-relatorio.component.scss']
})

export class CreateRelatorioComponent implements OnInit {

    public foto: Foto;

    constructor(private modalCtrl: ModalController, private camera: Camera, ) {
        this.foto = new Foto();
    }

    ngOnInit() { }

    closeModal() {
        this.modalCtrl.dismiss();
    }

    public getPhoto() {
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

    public save() {
        EventsService.get('save').emit(this.foto);
    }

}
