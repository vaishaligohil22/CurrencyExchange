import { AuthInterceptor } from './services/auth.interceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ExchangerateComponent } from './component/exchangerate/exchangerate.component';
import { FormsModule } from '@angular/forms';
import { FixerHttpClient } from './clients/fixer.httpclient';
import { ChartComponent } from './component/chart/chart.component';
import { DatePipe } from '@angular/common';
import { ChartsModule } from 'ng2-charts';

@NgModule({
  declarations: [
    AppComponent,
    ExchangerateComponent,
    ChartComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ChartsModule
  ],
  providers: [
    DatePipe,
    FixerHttpClient,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
