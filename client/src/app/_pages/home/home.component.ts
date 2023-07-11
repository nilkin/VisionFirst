import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { lastValueFrom } from 'rxjs';
import { DepartmentService } from 'src/app/_services/department.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  departments : any;

  registerMode: boolean = false;
  constructor(private message: NzMessageService,private departmentService :DepartmentService) {}
  ngOnInit(): void {this.getDepartments()};

  registerToggle(): void {
    this.registerMode = !this.registerMode;
  }

  learnMore(): void {
    this.message.info('Learn More button clicked!');
  }

  async getDepartments() {
    try {
      this.departments = await lastValueFrom(await this.departmentService.getDepartments());
    } catch (error) {
      console.error('Error retrieving departments:', error);
    }
  }

  cancelRegisterMode($event: any) {
   this.registerMode = $event;
  }
}
