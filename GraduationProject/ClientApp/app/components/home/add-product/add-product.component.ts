import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { ImageCroppedEvent } from 'ngx-image-cropper';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  options= [{ id: 1, name: 'Mohamed' }, { id: 2, name: 'ali' }];

  
  form = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    price: new FormControl('', Validators.required),
    condition: new FormControl('', Validators.required),
    productId: new FormControl('', Validators.required),
    images:new FormArray([],Validators.required)
    
  });

  imageChangedEvent: any = '';
  croppedImage: any = '';
  get name() {
    return this.form.get('name');
  }
  get images() {
    return this.form.get('images')! as FormArray
  }
  constructor() { }

  ngOnInit(): void {
  }
  OnAddPicture(event) {
    this.imageChangedEvent = event;
    document.getElementById("tansformation").classList.add("abs-form-block");
  }
  imageCropped(event: ImageCroppedEvent) {
    this.croppedImage = event.base64;
  } 
  DeleteCropper() {
    document.getElementById("tansformation").classList.remove("abs-form-block");
    (<HTMLInputElement>document.getElementById("image-button")).value = "";
  }
  AddImage=()=>
  {
    let name = (<HTMLInputElement>document.getElementById("image-button")).files[0].name;
    this.images.push(new FormControl({ value: this.croppedImage, name }));
    document.getElementById("tansformation").classList.remove("abs-form-block");
    (<HTMLInputElement>document.getElementById("image-button")).value = "";
    console.log(this.images);
  }
  imageLoaded() {
   
  }
cropperReady() {
    
}
loadImageFailed() {
   
}

}

