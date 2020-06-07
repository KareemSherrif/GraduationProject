export class ProductInfo {
    userProductId: number;
    productId: number;
    name: string;
    price: number;
    condition: number;
    images: ProductImageInfo[];
}

export class ProductImageInfo {
    image: string;
}