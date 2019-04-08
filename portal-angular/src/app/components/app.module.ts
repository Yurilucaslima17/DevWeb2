import { CrudComponentRegister } from './pages/crud/register/crud.register.component';
import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HeaderComponent} from './shared/header/header.component';
import { CrudComponent } from './pages/crud/crud.component';
import {AbsencesComponent} from './pages/absences/absences.component';
import {ScheduleComponent} from './pages/schedule/schedule.component';
import {ExtracurricularsComponent} from './pages/extracurriculars/extracurriculars.component';
import {LoginComponent} from './pages/login/login.component';
import {UserDetailsComponent} from './pages/user-details/user-details.component';
import {PageComponent} from './shared/page/page.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

@NgModule({
	declarations: [
		AppComponent,
		HeaderComponent,
		CrudComponent,
		AbsencesComponent,
		ScheduleComponent,
		ExtracurricularsComponent,
		LoginComponent,
		UserDetailsComponent,
		PageComponent,
		CrudComponentRegister
	],
	imports: [
		BrowserModule,
		AppRoutingModule,
		HttpClientModule,
		FormsModule
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule {
}
