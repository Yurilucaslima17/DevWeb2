import {AbsenceSemester} from './AbsenceSemester';

export class Absence {
	isFirstSemester: AbsenceSemester;

	constructor(
		public discipline: string,
		public credits: number,
		public january: number,
		public february: number,
		public march: number,
		public april: number,
		public may: number,
		public june: number,
		public july: number,
		public august: number,
		public september: number,
		public october: number,
		public november: number,
		public december: number
	) {
		this.hasAbsences();
	}

	getAbsences(): number[] {
		return this.getAbsencesOfSemester(AbsenceSemester.FIRST)
			.concat(
				this.getAbsencesOfSemester(AbsenceSemester.SECOND)
			);
	}

	getAbsencesOfSemester(firstSemester: AbsenceSemester): number[] {
		if (firstSemester === AbsenceSemester.FIRST) {
			return [
				this.january,
				this.february,
				this.march,
				this.april,
				this.may,
				this.june,
			];
		}

		return [
			this.july,
			this.august,
			this.september,
			this.october,
			this.november,
			this.december
		];
	}

	getMonthNames(firstSemester: AbsenceSemester): string[] {
		if (firstSemester === AbsenceSemester.FIRST) {
			return [
				'Janeiro',
				'Fevereiro',
				'Março',
				'Abril',
				'Maio',
				'Junho',
			];
		}

		return [
			'Julho',
			'Agosto',
			'Setembro',
			'Outubro',
			'Novembro',
			'Dezembro',
		];
	}

	getTotalAbsences(): number {
		let sum = 0;

		for (const month of this.getAbsences()) {
			sum += month;
		}

		return sum;
	}

	private determineIfFirstSemester(): AbsenceSemester {
		console.log(this.discipline);
		let index = 0;
		for (const item of this.getAbsences()) {
			if (item > 0) {
				if (index < 6) {
					return AbsenceSemester.FIRST;
				} else {
					return AbsenceSemester.SECOND;
				}
			}

			index++;
		}

		return AbsenceSemester.INCONCLUSIVE;
	}

	hasAbsences(): boolean {
		this.isFirstSemester = this.determineIfFirstSemester();

		return this.isFirstSemester !== AbsenceSemester.INCONCLUSIVE;
	}
}
