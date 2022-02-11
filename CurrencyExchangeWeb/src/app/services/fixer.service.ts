import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FixerHttpClient } from '../clients/fixer.httpclient';
import { IChart } from '../component/chart/chart.interface';
import { IExchangeRate } from '../component/exchangerate/exchangerate.interface';

@Injectable({
  providedIn: 'root'
})
export class FixerService {

  constructor(private httpClient: FixerHttpClient) { }

  getRate(from: string, to: string, date: string): Observable<IExchangeRate> {
    return this.httpClient.get(`ExchangeRate/GetExchangeRate?From=${from}&To=${to}&Date=${date}`);
  }

  getInternalRate(from: string, to: string, fromDate: string, toDate: string): Observable<IChart> {
    return this.httpClient.get(`Inernal?From=${from}&To=${to}&FromDate=${fromDate}&ToDate=${toDate}`);
  }
}
