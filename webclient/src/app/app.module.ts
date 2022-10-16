import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { FussballDeClientService } from './services/fussball-de-client.service';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, HttpClientModule],
  providers: [FussballDeClientService],
  bootstrap: [AppComponent],
})
export class AppModule {}
