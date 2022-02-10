import { AuthInterceptor } from './services/auth.interceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ExchangerateComponent } from './component/exchangerate/exchangerate.component';
import { FormsModule } from '@angular/forms';
import { FixerHttpClient } from './clients/fixer.httpclient';

@NgModule({
  declarations: [
    AppComponent,
    ExchangerateComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    FixerHttpClient,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
