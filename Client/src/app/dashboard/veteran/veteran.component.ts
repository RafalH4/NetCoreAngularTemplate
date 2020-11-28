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
  users:any
  
  constructor(private ds: VeteranDataServiceService, private userService: UserService) { }
  ngOnInit(): void {
    this.ds.getData().subscribe(x => {
      this.dataPassed = x;
      console.log(x)
    })
    this.userService.getVeterans().subscribe(x => console.log(x))

  }
  test(number): void {
    if(this.detailVeteran == number)
      this.detailVeteran = 0
      else
      this.detailVeteran = number
  }
}
