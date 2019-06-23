import { Component, OnInit, Input } from '@angular/core';
import { ServerService } from '../server.service';
import { TaxCalculation } from '../models/TaxCalculation';
import { TaxType } from '../models/TaxType';
import { PostalCode } from '../models/PostalCode';
import { FlatRate } from '../models/FlatRat';
import { ProgressiveRate } from '../models/ProgressiveRate';
import { TaxTypeEnum } from '../utilities/tax-type-enum';
import { StyleCompiler } from '@angular/compiler';
import { post } from 'selenium-webdriver/http';
import { bloomAdd } from '@angular/core/src/render3/di';

@Component({
  selector: 'app-calculations',
  templateUrl: './calculations.component.html'
})

export class CalculationsComponent implements OnInit {
  postalCodes: PostalCode[];
  @Input() userPostalCode = new PostalCode();
  annualIncome: number;
  monthlyIncome: number;
  canSubmit: boolean;
  calculatedTax: any;
  selectedItem: any;
  calculations: TaxCalculation;
  fullName: string;

  constructor(private server: ServerService) {
    this.calculatedTax = "";
    this.fullName = "";
  }

  ngOnInit() {

    this.canSubmit = false;
    var scope = this;

    scope.server.GetPostalCodes()
      .subscribe(i => {
        debugger;

        scope.postalCodes = i;
      });
  }

  userFullName(e) {
    debugger;
    this.fullName = e.target.value;
  }

  userIncomeInput(e) {
    debugger;

    var scope = this;
    scope.annualIncome = e.target.value.toFixed(2);
    scope.getMonthlyIncome();

    if (scope.userPostalCode != null) {
      scope.processUserInput();
    }
  }

  userPostalCodeInput(e) {
    var scope = this;

    var test;

    scope.postalCodes.forEach(function (item) {
      if (item.id == e) {
        
        var bleh = new PostalCode();
        bleh.id = item.id;
        bleh.codeName = item.codeName;
        bleh.taxType = item.taxType;

        test = item;
        
      }
    });

    scope.userPostalCode = test;
    scope.selectedItem = test;
    

    if (scope.annualIncome != null) {
      scope.processUserInput();
    }

  }

  processUserInput() {
    var scope = this;

    if (TaxTypeEnum.ProgressiveTax.toString() == scope.userPostalCode.taxTypeId) {
      scope.calcProgressiveTax();
    }

    else if (TaxTypeEnum.FlatValueTax.toString() == scope.userPostalCode.taxTypeId) {
      scope.calcFlatValueTax();
    }

    else if (TaxTypeEnum.FlatRateTax.toString() == scope.userPostalCode.taxTypeId) {
      scope.caclFlatRateTax();
    }

    scope.canSubmit = true;

  }

  calcProgressiveTax() {
    var scope = this;

    debugger;
    var income = scope.monthlyIncome;

    if (income <= 8350) {//10%
      var perc = scope.getPercentage(10);
      scope.calc(perc);

    } else if (income >= 8351 && income <= 33950) { // 15%

      var perc = scope.getPercentage(15);
      scope.calc(perc);

    } else if (income >= 33951 && income <= 82250) { // 25%
      var perc = scope.getPercentage(25);
      scope.calc(perc);

    } else if (income >= 82251 && income <= 171550) { //28%

      var perc = scope.getPercentage(28);
      scope.calc(perc);
    } else if (income >= 171551 && income <= 372950) {//33%

      var perc = scope.getPercentage(33);
      scope.calc(perc);
    }
    else if (income >= 372951) {//35%
      var perc = scope.getPercentage(35);
      scope.calc(perc);
    }

  }

  calcFlatValueTax() {
    var scope = this;
    debugger;
    if (scope.annualIncome < 200000)
      scope.calc(scope.getPercentage(5));
    else
      scope.calculatedTax = 10000;


  }

  caclFlatRateTax() {
    var scope = this;
    scope.calc(scope.getPercentage(17.5));
  }

  getMonthlyIncome() {
    this.monthlyIncome = this.annualIncome / 12;//convert annual income to a monthly income
  }

  getPercentage(val) {
    return val / 100;
  }

  calc(perc) {
    var scope = this;
    scope.calculatedTax = (perc * scope.annualIncome).toFixed(2);
  }

  addCalculation() {

    var scope = this;

    var tc = new TaxCalculation();
    tc.income = scope.annualIncome;
    tc.calculatedTax = scope.calculatedTax.toFixed(2);
    tc.postalCode = scope.userPostalCode.codeName;
    tc.fullName = scope.fullName;
    //tc.CreatedDate = Date.now();
    scope.calculations = JSON.parse(JSON.stringify(tc));

    debugger;
    scope.server.AddCalculation(scope.calculations).subscribe(i => {
      debugger;
      //this.onOrderSaved.emit(i);
    }, e => console.log(e));;

  }
}

