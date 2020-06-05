/** @format */

import { SearchElements } from "./../../../models/product";
import { ProductService } from "./../../../services/product.service";
import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators, FormArray } from "@angular/forms";
import { ImageCroppedEvent } from "ngx-image-cropper";

@Component({
	selector: "app-add-product",
	templateUrl: "./add-product.component.html",
	styleUrls: ["./add-product.component.css"],
})
export class AddProductComponent implements OnInit {
	options: SearchElements[] = [];
	filterdProduct: SearchElements[] = [];
	selctedElement: SearchElements = null;

	constructor(private service: ProductService) {}

	form = new FormGroup({
		name: new FormControl("", Validators.required),
		description: new FormControl("", Validators.required),
		price: new FormControl("", Validators.required),
		condition: new FormControl("", Validators.required),
		productId: new FormControl("", Validators.required),
		images: new FormArray([], Validators.required),
	});

	imageChangedEvent: any = "";
	croppedImage: any = "";
	get Name() {
		return this.form.get("name");
	}
	get images() {
		return this.form.get("images")! as FormArray;
	}

	ngOnInit(): void {}
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
	AddImage = () => {
		let name = (<HTMLInputElement>document.getElementById("image-button"))
			.files[0].name;
		this.images.push(new FormControl({ value: this.croppedImage, name }));
		document.getElementById("tansformation").classList.remove("abs-form-block");
		(<HTMLInputElement>document.getElementById("image-button")).value = "";
		console.log(this.images);
	};
	OnTextWrite() {
		this.service.GetNames(this.Name.value).subscribe((a) => {
			this.options = a;
		});
	}
	OnItemSelected(event) {
	
		this.filterdProduct = this.options.filter(
			(a) => a.name == event.option.value
		);
  }
  OnSelectChange(event) {
    this.selctedElement = this.filterdProduct.find(a => a.productId == event.target.value);
    console.log(this.selctedElement);
    
  }

  OnFormSubmit() {
    console.log(this.form.value);
  }

	imageLoaded() {}
	cropperReady() {}
	loadImageFailed() {}
}
