import { IonicModule } from '@ionic/angular';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CreateRelatorioComponent } from './create-relatorio.component';
import { Camera, CameraOptions } from '@ionic-native/camera/ngx';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
    ],

    declarations: [
        CreateRelatorioComponent
    ],

    exports: [
        CreateRelatorioComponent
    ],

    entryComponents: [
        CreateRelatorioComponent
    ],

    providers: [
        Camera
    ]
})

export class CreateRelatorioComponentModule { }
