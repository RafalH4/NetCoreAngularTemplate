import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { MainPageComponent } from './main-page/main-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { VeteranComponent } from './veteran/veteran.component';
import { BusinessmanComponent } from './businessman/businessman.component';
import { OrganizationComponent } from './organization/organization.component';
import { PromotionComponent } from './promotion/promotion.component';
import { ChartsModule } from 'ng2-charts';
import { VeteranDetailComponent } from './veteran/veteran-detail/veteran-detail.component';
import { BusinessmanSiteComponent } from './businessman-site/businessman-site.component';


@NgModule({
  declarations: [MainPageComponent, AdminPageComponent, HomeComponent, VeteranComponent, BusinessmanComponent, OrganizationComponent, PromotionComponent, VeteranDetailComponent, BusinessmanSiteComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    RouterModule,
    ChartsModule
  ]
})
export class DashboardModule { }
