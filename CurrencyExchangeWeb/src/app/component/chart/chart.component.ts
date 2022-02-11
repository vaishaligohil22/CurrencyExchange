import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { FixerService } from 'src/app/services/fixer.service';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  public lineChartData: ChartDataSets[] = [
    { data: [65, 59, 80, 81, 56, 55, 40], label: `EUR to NOK chart` },
  ];
  public lineChartLabels: Label[];
  public lineChartOptions: (ChartOptions & { annotation?: any }) = {
    responsive: true,
  };
  public lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'rgba(0,0,0,0)',
    },
  ];
  public lineChartLegend = true;
  public lineChartType = 'line';
  public lineChartPlugins = [];

  constructor(private fixerService: FixerService, public datepipe: DatePipe) { }

  ngOnInit(): void {
    this.GetRate();
  }

  GetRate(): void {
    let currentdate = this.datepipe.transform(new Date(), 'yyyy-MM-dd');
    let today = new Date();
    let last3months = this.datepipe.transform(new Date(today.setMonth(today.getMonth() - 3)), 'yyyy-MM-dd');

    this.fixerService.getInternalRate('EUR', 'NOK', last3months, currentdate).subscribe(
      (data) => {
        const result = [].concat(...data.items.map(
          r => r.rate
        ));
        const unique = [...new Set(data.items.map(item => this.datepipe.transform(item.date, 'MMM d, y')))];

        this.lineChartData[0].data = result;
        this.lineChartLabels = unique;

      }, (error) => {
        console.log(error);
      });
  }

}
