import { Component, OnInit, Input } from '@angular/core';
import { ServerService } from '../server.service';
import { TaxCalculation } from '../models/TaxCalculation';
import { TaxType } from '../models/TaxType';
import { PostalCode } from '../models/PostalCode';
import { FlatRate } from '../models/FlatRat';
import { ProgressiveRate } from '../models/ProgressiveRate';
import { debug } from 'util';

@Component({
  selector: 'app-calculations',
  templateUrl: './calculations.component.html'
})

export class CalculationsComponent {
  postalCodes: PostalCode[];


  constructor(public server: ServerService) {
    debugger;
    server.GetPostalCodes().subscribe(i => this.postalCodes = i);
    debugger;
  }
}

