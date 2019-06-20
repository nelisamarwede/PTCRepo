import { Component } from '@angular/core';
import { PostalCode } from '../models/PostalCode';
import { ServerService } from '../server.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  postalCodes: PostalCode[];

  constructor(public server: ServerService) {
    server.GetPostalCodes().subscribe(i => this.postalCodes = i);
  }
}
