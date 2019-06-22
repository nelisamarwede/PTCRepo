import { TaxType } from "./TaxType";

export class PostalCode {
  public id: number;
  public codeName: string;
  public taxTypeId: string;
  public taxType: TaxType;

  constructor() {
    this.taxType = new TaxType()
  }
}
