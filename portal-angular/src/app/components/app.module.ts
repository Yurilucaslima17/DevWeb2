import { CrudRegisterComponent } from './pages/crud/register/crud.register.component';
import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HeaderComponent} from './shared/header/header.component';
import { CrudComponent } from './pages/crud/crud.component';
import {AbsencesComponent} from './pages/absences/absences.component';
import {UserListComponent} from './pages/userList/UserList.component';
import {ExtracurricularsComponent} from './pages/extracurriculars/extracurriculars.component';
import {LoginComponent} from './pages/login/login.component';
import {UserDetailsComponent} from './pages/user-details/user-details.component';
import {PageComponent} from './shared/page/page.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { UserRegisterComponent } from './pages/user-details/user-register/user-register.component';

@NgModule({
	declarations: [
		AppComponent,
		HeaderComponent,
		CrudComponent,
		AbsencesComponent,
		UserListComponent,
		ExtracurricularsComponent,
		LoginComponent,
		UserDetailsComponent,
		PageComponent,
		CrudRegisterComponent,
		UserRegisterComponent
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
