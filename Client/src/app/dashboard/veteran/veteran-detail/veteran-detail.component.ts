import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Output, EventEmitter } from '@angular/core';
import { VeteranDataServiceService } from '../../services/veteran-data-service.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-veteran-detail',
  templateUrl: './veteran-detail.component.html',
  styleUrls: ['./veteran-detail.component.scss']
})
export class VeteranDetailComponent implements OnInit {
  @Output() newItemEvent = new EventEmitter<string>();
  param: string = "";
  @Input() user : any
  constructor(private route: ActivatedRoute, 
    private ds: VeteranDataServiceService) { }

  ngOnInit(): void {
    this.route.paramMap.forEach(({params}:Params)=>{
      this.param = params['id']
      this.ds.sendData(params['id']);
      })
  }
}
