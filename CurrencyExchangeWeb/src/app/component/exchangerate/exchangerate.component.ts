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
  date = new Date();
  amount: number = 0;
  message: string = '';

  constructor(private fixerService: FixerService) { }

  ngOnInit(): void { }

  GetRate(): void {
    this.fixerService.getRate(this.from, this.to, this.date).subscribe(
      (data) => {
        if (data.success) {
          let finalAmount = data.rates[this.to] * this.amount;
          alert(`${this.from} to ${this.to} for amount ${this.amount} = ${finalAmount}`);
        }
        else
          alert("Unsuccessful");
      }, (error) => {
        console.log(error);
      });
  }
}
