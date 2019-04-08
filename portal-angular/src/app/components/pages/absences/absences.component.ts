import {Component, OnInit} from '@angular/core';
import {BasePortalComponent} from '../../shared/base-portal.component';
import {Absence} from '../../../models/Absence';
import {AbsenceSemester} from '../../../models/AbsenceSemester';

@Component({
	selector: 'app-absences',
	templateUrl: './absences.component.html',
	styleUrls: ['./absences.component.scss']
})
export class AbsencesComponent extends BasePortalComponent implements OnInit {
	semester: AbsenceSemester;

	absences: Absence[] = [
		new Absence('Mat. 1', 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		new Absence('Mat. 2', 2, 2, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0),
		new Absence('Mat. 3', 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		new Absence('Mat. 4', 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	];

	constructor() {
		super();
	}

	ngOnInit() {
		this.semester = this.determineSemester();
	}

	private determineSemester(): AbsenceSemester {
		for (const absence of this.absences) {
			if (absence.hasAbsences()) {
				return absence.isFirstSemester;
			}
		}

		return AbsenceSemester.INCONCLUSIVE;
	}
}
