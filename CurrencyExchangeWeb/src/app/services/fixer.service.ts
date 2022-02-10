import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FixerHttpClient } from '../clients/fixer.httpclient';
import { IExchangeRate } from '../component/exchangerate/exchangerate.interface';

@Injectable({
  providedIn: 'root'
})
export class FixerService {

  constructor(private httpClient: FixerHttpClient) { }

  getRate(from: string, to: string, date: Date): Observable<IExchangeRate> {
    return this.httpClient.get(`ExchangeRate/GetExchangeRate?From=${from}&To=${to}&Date=${date}`);
  }
}
