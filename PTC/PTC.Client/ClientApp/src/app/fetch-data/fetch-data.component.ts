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
        
        scope.calculations = i;
      });
  }

  updateCalculation(c: TaxCalculation) {
    var scope = this;

    scope.calculation = JSON.parse(JSON.stringify(c));
    scope.server.UpdateCalculation(scope.calculation).subscribe(i => {
      console.log(i)
      alert("Updated successfully.")
    });

  }

  userIncomeInput(c: TaxCalculation) {
    var scope = this;

    scope.server.CalculateTax(JSON.parse(JSON.stringify(c))).subscribe(m => c == m);
  }

  deleteCalculation(c: TaxCalculation, index: number) {
    
    var scope = this;

    var r = confirm("Are you sure you want to DELETE this calculation!");
    if (r == true) {
      //.subscribe(i => this.suppliers = i)
      scope.calculation = JSON.parse(JSON.stringify(c));
      scope.server.DeleteCalculation(scope.calculation.id).subscribe(m => {
        console.log(m)
        this.calculations.splice(index, 1);
        alert('Deleted successfully.')
      });
    }
    else {
          //txt = "You pressed Cancel!";
        }
  }

}
