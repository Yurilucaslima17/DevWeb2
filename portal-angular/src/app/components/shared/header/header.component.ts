import {Component, Input, OnInit} from '@angular/core';
import {HeaderOptions} from '../../../models/constants/header-options.enum';
import {BasePortalComponent} from '../base-portal.component';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthToken} from '../../../models/AuthToken';

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: [
		'./header.component.scss',
	]
})
export class HeaderComponent extends BasePortalComponent implements OnInit {

	@Input() selectedItem: HeaderOptions;

	@Input() isLogin = false;

	constructor(private router: Router, private route: ActivatedRoute) {
		super();
	}

	ngOnInit() {
	}

	onSignOutClick() {
		AuthToken.clearToken();

		this.router.navigate(['/entrar'], {
			relativeTo: this.route
		});
	}
}
