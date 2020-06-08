export class AddProduct {
    description: string;
    name: string;
    price: number;
    condition: number;
    productId: number;
    images: ImageProductViewModel[];
}
export class ImageProductViewModel {
    value: string;
    name: string;
}