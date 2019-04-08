import {Component, OnInit} from '@angular/core';
import {BasePortalComponent} from '../../shared/base-portal.component';
import {Schedule} from '../../../models/Schedule';

@Component({
	selector: 'app-schedule',
	templateUrl: './schedule.component.html',
	styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent extends BasePortalComponent implements OnInit {

	schedule: Schedule[][] = [];

	daysOfWeek = [
		'Domingo',
		'Segunda',
		'Terça',
		'Quarta',
		'Quinta',
		'Sexta',
		'Sábado'
	];

	constructor() {
		super();
	}

	ngOnInit() {
		for (let i = 0; i < this.daysOfWeek.length; i++) {
			this.schedule[i] = [];
		}

		const mockedSchedule = [
			new Schedule(4, 'Mat. 4', 'Joãozinho', 'C49', '19:00'),
			new Schedule(1, 'Mat. 2', 'Joãozinho', 'C49', '21:00'),
			new Schedule(3, 'Mat. 3', 'Joãozinho', 'C49', '21:00'),
			new Schedule(1, 'Mat. 1', 'Joãozinho', 'C49', '19:00'),
		];

		for (const item of mockedSchedule) {
			this.schedule[item.day].push(item);
		}

		for (let item of this.schedule) {
			item = item.sort((a, b) => {
				if (a.day === b.day) {
					return a.hour > b.hour ? 1 : -1;
				}

				return a.day > b.day ? 1 : -1;
			});
		}
	}

	getClasses(fullSchedule: Schedule[], day: number): Schedule[] {
		return this.schedule[day];
	}
}
