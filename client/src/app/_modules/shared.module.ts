import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { ReactiveFormsModule } from '@angular/forms';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { ToastrModule } from 'ngx-toastr';
import { NZ_I18N, en_US } from 'ng-zorro-antd/i18n';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    MatButtonModule, 
    MatMenuModule,
    NzMessageModule,
    NzButtonModule,
    NzLayoutModule,
    ReactiveFormsModule,
    NzFormModule,
    NzRadioModule,
    ToastrModule.forRoot({
      positionClass :'toast-bottom-right'
    })
  ],
  exports:[
    BrowserAnimationsModule,
    MatButtonModule, 
    MatMenuModule,
    NzMessageModule,
    NzButtonModule,
    NzLayoutModule,
    ReactiveFormsModule,
    NzFormModule,
    NzRadioModule,
    ToastrModule
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US },DatePipe],
})
export class SharedModule { }
