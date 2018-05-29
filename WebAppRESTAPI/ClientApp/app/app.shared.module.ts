import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchEmployeeComponent } from './components/fetchemployee/fetchemployee.component';
import { EmployeeService } from './services/empservice.service';
import { createemployee } from './components/addemployee/addEmployee.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        FetchEmployeeComponent,
        createemployee
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'fetch-employee', component: FetchEmployeeComponent },  
            { path: 'register-employee', component: createemployee },
            { path: 'employee/edit/:empno', component: createemployee },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [EmployeeService]  
})
export class AppModuleShared {
}
