import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  registerMode: boolean = false;
  constructor(private message: NzMessageService) {}
  ngOnInit(): void {}

  register(): void {
    this.registerMode = !this.registerMode;
  }

  learnMore(): void {
    this.message.info('Learn More button clicked!');
    // Add your "Learn More" logic here
  }
}
