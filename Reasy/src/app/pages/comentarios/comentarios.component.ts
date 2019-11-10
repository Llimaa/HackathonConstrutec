import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
@Component({
    selector: 'component-item-perfil',
    templateUrl: 'comentarios.component.html',
    styleUrls: ['comentarios.component.scss']
})

export class ComentarioComponent implements OnInit {

    constructor(private modalCtrl: ModalController) { }

    ngOnInit() { }

    closeModal() {
        this.modalCtrl.dismiss();
    }

}
