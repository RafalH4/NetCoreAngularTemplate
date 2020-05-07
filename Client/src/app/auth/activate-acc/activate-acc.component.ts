import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-activate-acc',
  templateUrl: './activate-acc.component.html',
  styleUrls: ['./activate-acc.component.scss']
})
export class ActivateAccComponent implements OnInit {

  activateForm: FormGroup
  email: string
  key: string
  constructor(private route: ActivatedRoute,
    private fb: FormBuilder,
    private _authService: AuthService) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.email = params['email'];
      this.key = params['key'];
    })

    this.activateForm = this.fb.group({
      email: [this.email, Validators.required],
      activateKey:[this.key, Validators.required]
    })
  }

  activate(){
    this._authService.activateAccount(this.activateForm.value).subscribe(
      response => console.log("Udało się"),
      error => console.log(error) 
    )
  }

}
