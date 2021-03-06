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
    return this.http.get<TaxCalculation[]>(this.GetUrl("Calculation"));
  }

  public GetPostalCodes(): Observable<PostalCode[]> {
    return this.http.get<PostalCode[]>(this.GetUrl("PostalCode"));
  }

  public GetTaxTypes(): Observable<TaxType[]> {
    return this.http.get<TaxType[]>(this.GetUrl("TaxCalculationType"));
  }

  public AddCalculation(calculation: TaxCalculation): Observable<TaxCalculation> {
    return this.http.put<TaxCalculation>(this.GetUrl("Calculation"), calculation);
  }
  public UpdateCalculation(calculation: TaxCalculation): Observable<TaxCalculation> {
    return this.http.patch<TaxCalculation>(this.GetUrl("Calculation"), calculation);
  }


  public DeleteCalculation(calcId: number): Observable<boolean> {
    return this.http.post<boolean>(this.GetUrl("Calculation"), calcId);
  }

  public CalculateTax(calculation: TaxCalculation): Observable<TaxCalculation> {
    return this.http.patch<TaxCalculation>(this.GetUrl("Accelerator"), calculation);
  }

}
