import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './_pages/home/home.component';
import { DepartmentListComponent } from './_pages/depatrments/department-list/department-list.component';
import { DepartmentDetailComponent } from './_pages/depatrments/department-detail/department-detail.component';
import { authGuard } from './_guards/Auth.guard';
import { NotFoundComponent } from './_errors/not-found/not-found.component';
import { ServerErrorComponent } from './_errors/server-error/server-error.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      { path: 'departments', component: DepartmentListComponent },
      { path: 'departments/:id', component: DepartmentDetailComponent },
    ],
  },

  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
