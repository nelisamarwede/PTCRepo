//import { Component } from '@angular/core';
import { Component, OnInit, Input, Output } from '@angular/core';
import { ServerService } from '../server.service';
import { TaxCalculation } from '../models/TaxCalculation';
import { post } from 'selenium-webdriver/http';
import { bloomAdd } from '@angular/core/src/render3/di';
import { debug } from 'util';



@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  calculations: TaxCalculation[];
  calculation: TaxCalculation;

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

  updateCalculation(c: TaxCalculation) {
    var scope = this;

    scope.calculation = JSON.parse(JSON.stringify(c));
    scope.server.UpdateCalculation(scope.calculation)
    debugger;
  }

  deleteCalculation(c: TaxCalculation) {
    debugger;
    var scope = this;

    scope.calculation = JSON.parse(JSON.stringify(c));
    //scope.server.DeleteCalculation(scope.calculation);
  }

}
