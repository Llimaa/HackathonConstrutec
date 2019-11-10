import { IonicModule } from '@ionic/angular';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { ComentarioComponent } from './comentarios.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
    ],

    declarations: [
        ComentarioComponent
    ],

    exports: [
        ComentarioComponent
    ],

    entryComponents: [
        ComentarioComponent
    ]
})

export class ComentariosComponentModule { }
