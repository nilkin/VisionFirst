import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './_pages/home/home.component';
import { DepartmentListComponent } from './_pages/depatrments/department-list/department-list.component';
import { DepartmentDetailComponent } from './_pages/depatrments/department-detail/department-detail.component';

const routes: Routes = [
  {path:"",component: HomeComponent},
  {path:"departments",component: DepartmentListComponent},
  {path:"departments/:id",component: DepartmentDetailComponent},
  {path:"**",component: HomeComponent,pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
