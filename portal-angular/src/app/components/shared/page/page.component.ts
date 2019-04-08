import {Component, Input, OnInit} from '@angular/core';
import {BasePortalComponent} from '../base-portal.component';
import {HeaderOptions} from '../../../models/constants/header-options.enum';

@Component({
	selector: 'app-page',
	templateUrl: './page.component.html',
	styleUrls: [
		'./page.component.scss'
	]
})
export class PageComponent extends BasePortalComponent implements OnInit {

	@Input() navSelectedItem: HeaderOptions;

	@Input() isLogin = false;

	constructor() {
		super();
	}

	ngOnInit() {
	}

}
