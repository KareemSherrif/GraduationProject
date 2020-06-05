export class SearchElements {
    productId: number;
    name: string;
    brandName: number;
    brandID: number;
    modelID: number;
    modelName: number;
    attributes: ProductAttributes[];
}
export class ProductAttributes {
    iD: number;
    attributeName: string;
    value: string;
    productId: number;
  
}