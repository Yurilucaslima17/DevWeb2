import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {AuthProxy} from '../../../models/api/AuthProxy';
import {InvalidArgumentProxy} from '../../../models/api/InvalidArgumentProxy';
import {AuthToken} from '../../../models/AuthToken';
import {ActivatedRoute, Params, Router} from '@angular/router';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

	isRequesting = false;

	errors: string[] = [];

	password = '';
	username = '';

	constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) {
	}

	ngOnInit() {
		const unauthorized = this.route.snapshot.queryParams['unauthorized'];

		if (unauthorized) {
			this.errors.push('Você não está logado ainda.');
		}
	}

	getErrors(errors: string[]): string {
		const errorsText = '';
		for (const error of errors) {
			errorsText.concat('* ' + error + '\n');
		}

		return errorsText;
	}

	onLoginClick() {
		this.errors = [];

		if (this.username.length === 0 || this.password.length === 0) {
			this.errors.push('Preencha todos os campos.');
			return;
		}

		AuthToken.setToken('Bearer 432j54gh345f45535g43fgh');

		this.router.navigate(['/'], {
			relativeTo: this.route
		});
	}
}
