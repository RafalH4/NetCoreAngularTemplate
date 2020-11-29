import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { UserService } from '../services/user.service';
import { VeteranDataServiceService } from '../services/veteran-data-service.service';

@Component({
  selector: 'app-veteran',
  templateUrl: './veteran.component.html',
  styleUrls: ['./veteran.component.scss']
})
export class VeteranComponent implements OnInit {
  dataPassed: any;
  subscription: Subscription;
  detailVeteran = 0;
  tableNumber = 0;
  users:any;
  unActiveUsers: any;

  constructor(private ds: VeteranDataServiceService, private userService: UserService) { }
  ngOnInit(): void {
    this.ds.getData().subscribe(x => {
      this.dataPassed = x;
    })
    this.userService.getVeterans().subscribe(x => {
      this.users = x;
    })
    this.userService.getVeteransUnactive().subscribe(x => {
      this.unActiveUsers = x;
    })

  }
  test(number, table): void {
    if(this.detailVeteran == number)
    {
      this.detailVeteran = 0
      this.tableNumber = 0
    }
    else
    {
      this.detailVeteran = number
      this.tableNumber=table
    }
  }
}
