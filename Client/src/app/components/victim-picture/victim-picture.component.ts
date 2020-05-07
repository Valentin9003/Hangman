import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'victim-picture',
  templateUrl: './victim-picture.component.html',
  styleUrls: ['./victim-picture.component.css']
})
export class VictimPictureComponent {

@Input() victimPicture: any;

constructor() { }

  ngOnInit(): void {
  }
}
