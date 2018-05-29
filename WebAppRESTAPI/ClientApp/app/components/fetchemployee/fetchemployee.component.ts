import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../services/empservice.service'

@Component({
    templateUrl: './fetchemployee.component.html'
})

export class FetchEmployeeComponent {
    public empList: EmployeeData[];

    constructor(public http: Http, private _router: Router, private _employeeService: EmployeeService) {
        this.getEmployees();
    }

    getEmployees() {
        this._employeeService.getEmployees().subscribe(
            data => this.empList = data
        )
    }

    delete(empno: number) {
        var ans = confirm("Do you want to delete customer with Number: " + empno);
        if (ans) {
            this._employeeService.deleteEmployee(empno).subscribe((data) => {
                this.getEmployees();
            }, error => console.error(error))
        }
    }
}
interface EmployeeData { 
    empno: number;
    ename: string;
    job: string;
    mgr: number;
    hiredate: Date;
    sal: number;
    comm: number;
    deptno: number;    
}