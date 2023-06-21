import { HttpClient } from '@angular/common/http';
import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  department:any;

  constructor(private http: HttpClient) {};

  ngOnInit(): void {
      this.http.get("https://localhost:5001/api/department/list").subscribe(
        {
          next : response => this.department = response,
          error: error => console.log(error)
        }
      )
  }
}
