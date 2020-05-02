import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'victim-picture',
  templateUrl: './victim-picture.component.html',
  styleUrls: ['./victim-picture.component.css']
})
export class VictimPictureComponent {

@Input() victimPicture: string = 'https://terminal3.bg/wp-content/uploads/2018/11/46453314_260179574654234_3374570939931951104_n-681x491.jpg'

constructor() { }

  ngOnInit(): void {
  }
}
