import { Component } from '@angular/core';
import { BasePortalComponent } from 'src/app/components/shared/base-portal.component';

@Component({
	selector: 'app-crud-register',
	templateUrl: './crud.register.component.html',
	styleUrls: ['./crud.register.component.scss']
})

export class CrudComponentRegister extends BasePortalComponent {
	constructor() {
	 super();
	}
}


