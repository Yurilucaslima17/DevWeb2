import {Component, OnInit} from '@angular/core';
import {BasePortalComponent} from '../../shared/base-portal.component';
import {Extracurricular} from '../../../models/Extracurricular';

@Component({
	selector: 'app-extracurriculars',
	templateUrl: './extracurriculars.component.html',
	styleUrls: ['./extracurriculars.component.scss']
})
export class ExtracurricularsComponent extends BasePortalComponent implements OnInit {

	extracurriculars: Extracurricular[] = [
		new Extracurricular('Ativ. 1', 15),
		new Extracurricular('Ativ. 2', 3),
		new Extracurricular('Ativ. 3', 6),
		new Extracurricular('Ativ. 4', 9),
	];

	constructor() {
		super();
	}

	ngOnInit() {
	}

	getTotalHours(items: Extracurricular[]): number {
		let sum = 0;

		for (const item of items) {
			sum += item.hours;
		}

		return sum;
	}
}
