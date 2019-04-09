import { User } from './../../../models/User';
import { Crud } from '../../../models/Crud';
import {Component, OnInit} from '@angular/core';
import {BasePortalComponent} from '../../shared/base-portal.component';

@Component({
	selector: 'app-crud',
	templateUrl: './crud.component.html',
	styleUrls: ['./crud.component.scss']
})
export class CrudComponent extends BasePortalComponent implements OnInit {

	cruds: Crud[] = [
		new Crud('Mat. 1', new User(1, '070809', 'José Domingues', 'josé@gmail.com', 3),
		new User(1, '070809', 'José', 'josé@gmail.com', 3), 3),
		new Crud('Mat. 2', new User(2, '070810', 'José2', 'josé2@gmail.com', 2),
		new User(1, '070809', 'José', 'josé@gmail.com', 3), 4),
		new Crud('Mat. 3', new User(3, '070809', 'Susana', 'susana@gmail.com', 1),
		new User(1, '070809', 'josé Dirceu', 'josé@gmail.com', 3), 5),
		new Crud('Mat. 4', new User(1, '070812', 'Maria', 'maria@gmail.com', 3),
		new User(1, '070809', 'José', 'josé@gmail.com', 3), 6),
	];

	constructor() {
		super();
	}

	ngOnInit() {
	}
}
