import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchEmployeeComponent } from '../fetchemployee/fetchemployee.component';
import { EmployeeService } from '../../services/empservice.service';

@Component({
    templateUrl: './AddEmployee.component.html'
})

export class createemployee implements OnInit {
    employeeForm: FormGroup;
    title: string = "Create";

    empno: number = 0;
    errorMessage: any;
    deptList: Array<any> = [];

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _employeeService: EmployeeService, private _router: Router) {

        if (this._avRoute.snapshot.params["empno"]) {
            this.empno = this._avRoute.snapshot.params["empno"];
        }

        this.employeeForm = this._fb.group({
            empno: 0,
            ename: ['', [Validators.required]],
            job: ['', [Validators.required]],
            mgr: ['', [Validators.required]],
            hiredate: ['', [Validators.required]],
            sal: ['', [Validators.required]],
            comm: ['', [Validators.required]],
            deptno: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        this._employeeService.getDeptList().subscribe(
            data => this.deptList = data
        )

        if (this.empno > 0) {
            this.title = "Edit";
            this._employeeService.getEmployeeById(this.empno)
                .subscribe(resp => this.employeeForm.setValue(resp)
                    , error => this.errorMessage = error);
        }
    }

    save() {
        //if (!this.employeeForm.valid) {
        //    return;
        //}
        if (this.title == "Create") {
            this._employeeService.saveEmployee(this.employeeForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-employee']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._employeeService.updateEmployee(this.employeeForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-employee']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/fetch-employee']);
    }

    //get empno() { return this.employeeForm.get('empno'); }    
    //get ename() { return this.employeeForm.get('ename'); }    
    //get deptno() { return this.employeeForm.get('deptno'); }    
}