import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { HomeComponent } from './home/home.component';
import { VeteranComponent } from './veteran/veteran.component';
import { BusinessmanComponent } from './businessman/businessman.component';
import { OrganizationComponent } from './organization/organization.component';
import { PromotionComponent } from './promotion/promotion.component';
import { VeteranDetailComponent } from './veteran/veteran-detail/veteran-detail.component';


const routes: Routes = [
  {
    path: '',
    component: MainPageComponent,
    children: [
      { path: '', redirectTo: 'home'},
      { path: 'home', component: HomeComponent },
      { path: 'veteran', component: VeteranComponent},
      { path: 'businessman', component: BusinessmanComponent },
      { path: 'organization', component: OrganizationComponent },
      { path: 'promotion', component: PromotionComponent },
    ]
  },
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class DashboardRoutingModule { }
