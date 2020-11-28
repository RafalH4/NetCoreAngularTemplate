import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  /*https://valor-software.com/ng2-charts/#/DoughnutChart*/
  constructor() { }
  /*Bar Plot */
  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true
  };
  public barChartLabels = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
  public barChartType = 'bar';
  public barChartLegend = true;
  public barChartData = [
    {data: [65, 59, 80, 81, 56, 55, 40], label: 'Series A'},
    {data: [28, 48, 40, 19, 86, 27, 90], label: 'Series B'},
    {data: [65, 59, 80, 81, 56, 55, 40], label: 'Series C'},
    {data: [28, 48, 40, 19, 86, 27, 90], label: 'Series D'},
  ];
  public barChartColors = [
    {backgroundColor: '#9E7394'},
    {backgroundColor: '#CADC79'},
    {backgroundColor: '#E95C4B'},
    {backgroundColor: '#b7dbff'}
  ];

  /*Doughnut Chart */
  public doughnutChartLabels = ['Download Sales', 'In-Store Sales', 'Mail-Order Sales'];
  public doughnutChartData = [
    [350, 450, 100],
  ];
  public doughnutChartType = 'doughnut';
  public doughnutChartColors = [{backgroundColor: ['#9E7394', '#CADC79', '#E95C4B']}]
  public doughnutChartColors2 = [{backgroundColor: ['#b7dbff', '#FF9AA2', '#BFFCC6']}]

  ngOnInit(): void {
  }

}
