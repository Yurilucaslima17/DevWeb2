import { ServiceComponent } from '../../../models/api/service.component';
import {Component, OnInit} from '@angular/core';
import {BasePortalComponent} from '../../shared/base-portal.component';
import {User} from '../../../models/User';

@Component({
	selector: 'app-UserList',
	templateUrl: './UserList.component.html',
	styleUrls: ['./UserList.component.scss']
})
export class UserListComponent extends BasePortalComponent implements OnInit {

	constructor() {
		super();
	}



	ngOnInit() {
	//	let users: Array<User> = getUsers() as User;
	}
}
