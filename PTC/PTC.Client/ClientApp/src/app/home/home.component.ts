//import { Component } from '@angular/core';
import { Component, OnInit, Input } from '@angular/core';
import { ServerService } from '../server.service';
import { TaxCalculation } from '../models/TaxCalculation';
import { post } from 'selenium-webdriver/http';
import { bloomAdd } from '@angular/core/src/render3/di';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  //postalCodes: PostalCode[];
  calculations: TaxCalculation[];

  constructor(private server: ServerService) {
    //server.GetPostalCodes().subscribe(i => this.postalCodes = i);
  }

  ngOnInit() {
    var scope = this;

    scope.server.GetCalculations()
      .subscribe(i => {
        debugger;
        scope.calculations = i;
      });
  }
}
