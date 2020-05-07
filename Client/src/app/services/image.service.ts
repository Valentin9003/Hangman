import { Injectable } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser'

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(private sanitizer: DomSanitizer) { }

  getImage(data: string): any{
    let objectURL = 'data:image/jpg;base64,' + data;
    return this.sanitizer.bypassSecurityTrustUrl(objectURL);
  }
}
