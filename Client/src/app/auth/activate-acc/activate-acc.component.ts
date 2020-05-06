import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-activate-acc',
  templateUrl: './activate-acc.component.html',
  styleUrls: ['./activate-acc.component.scss']
})
export class ActivateAccComponent implements OnInit {

  email: string
  key: string
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.email = params['email'];
      this.key = params['key'];
      console.log(this.email)
    })
  }

}
