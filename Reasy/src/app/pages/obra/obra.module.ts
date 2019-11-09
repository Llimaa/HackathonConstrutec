import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { IonicModule } from '@ionic/angular';
import { ObraPage } from './obra.page';
import { NavbarTabsComponentModule } from 'src/app/components/navbar-tabs/navbar-tabs.module';
import { UploadPhotoService } from 'src/app/services/upload-photo-service/upload-photo-service';
import { Camera } from '@ionic-native/camera/ngx';

const routes: Routes = [
  {
    path: '',
    component: ObraPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes),
    NavbarTabsComponentModule
  ],
  declarations: [ObraPage],

  providers: [
    UploadPhotoService,
    Camera
  ]
})
export class ObraPageModule { }
