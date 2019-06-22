import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs/Observable';
import { PostalCode } from './models/PostalCode';
import { TaxType } from './models/TaxType';
import { TaxCalculation } from './models/TaxCalculation';

@Injectable()

export class ServerService {

  constructor(private http: HttpClient) { }

  private GetUrl(resource: string): string {
    debugger;
    return `${environment.baseAddress}/${resource}`;
  }

  public GetCalculations(): Observable<TaxCalculation[]> {
    return this.http.get<TaxCalculation[]>(this.GetUrl("Calculations"));
  }

  public GetPostalCodes(): Observable<PostalCode[]> {
    return this.http.get<PostalCode[]>(this.GetUrl("PostalCode"));
  }

  public GetTaxTypes(): Observable<TaxType[]> {
    return this.http.get<TaxType[]>(this.GetUrl("TaxCalculationType"));
  }

  public AddCalculation(calculation: TaxCalculation): Observable<number> {
    debugger;
    return this.http.post<number>(this.GetUrl("Calculations"), calculation);
    //return this.http.post<number>(this.GetUrl("Supplier"), supplier);
  }
  //public AddSupplier(supplier: Supplier): Observable<number> {
  //  return this.http.post<number>(this.GetUrl("Supplier"), supplier);
  //}
}
