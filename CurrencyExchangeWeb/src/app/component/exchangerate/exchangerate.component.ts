import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FixerService } from 'src/app/services/fixer.service';

@Component({
  selector: 'app-exchangerate',
  templateUrl: './exchangerate.component.html',
  styleUrls: ['./exchangerate.component.css']
})
export class ExchangerateComponent implements OnInit {
  from: string = '';
  to: string = '';
  date = this.datepipe.transform(new Date(), 'yyyy-MM-dd');
  amount: number = 0;
  message: string = '';

  constructor(private fixerService: FixerService, public datepipe: DatePipe) { }

  ngOnInit(): void { }

  GetRate(): void {
    this.fixerService.getRate(this.from, this.to, this.date).subscribe(
      (data) => {
        if (data.success) {
          let finalAmount = data.rates[this.to] * this.amount;
          this.message = `${this.from} to ${this.to} for amount ${this.amount} = ${finalAmount}`;
        }
        else
          this.message = "Unsuccessful";
      }, (error) => {
        this.message = error;
      });
  }
}
