import { Component, OnInit, ViewChild, AfterViewInit, ElementRef  } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
//import {} from 'googlemaps';

@Component({
  selector: 'app-businessman-site',
  templateUrl: './businessman-site.component.html',
  styleUrls: ['./businessman-site.component.scss']
})
export class BusinessmanSiteComponent implements OnInit {
  @ViewChild('mapContainer', {static: false}) gmap: ElementRef;
  
  constructor(private authService: AuthService) { }


  ngOnInit(): void {

  }

  logout(){
    this.authService.logout();
  }

}