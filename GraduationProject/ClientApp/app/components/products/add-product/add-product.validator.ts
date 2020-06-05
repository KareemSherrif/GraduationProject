import { ProductService } from './../../../services/product.service';
import { AbstractControl, ValidationErrors } from '@angular/forms';

export class ProductValidators{

    
    static  ValidateOnName(control: AbstractControl,services:ProductService): Promise<ValidationErrors|null>{
        
        return new Promise((resolve, reject) => {
          
            
            
        })
    }
}