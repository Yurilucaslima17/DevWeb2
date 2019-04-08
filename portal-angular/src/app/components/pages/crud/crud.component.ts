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
		new Crud('Mat. 1', new User(1, '070809', 'José Domingues', '123.456.789-00', 'josé@gmail.com', 3),
		new User(1, '070809', 'José', '123.456.789-00', 'josé@gmail.com', 3), 3),
		new Crud('Mat. 2', new User(2, '070810', 'José2', '123.456.789-00', 'josé2@gmail.com', 2),
		new User(1, '070809', 'José', '123.456.789-00', 'josé@gmail.com', 3), 4),
		new Crud('Mat. 3', new User(3, '070809', 'Susana Bispo dos Santos', '987.654.321-99', 'susana@gmail.com', 1),
		new User(1, '070809', 'josé Dirceu', '123.456.789-00', 'josé@gmail.com', 3), 5),
		new Crud('Mat. 4', new User(1, '070812', 'Maria', '159.753.147-65', 'maria@gmail.com', 3),
		new User(1, '070809', 'José', '123.456.789-00', 'josé@gmail.com', 3), 6),
	];

	constructor() {
		super();
	}

	ngOnInit() {
	}
}
