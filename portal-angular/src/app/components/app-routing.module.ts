import { CrudComponentRegister } from './pages/crud/register/crud.register.component';
import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { CrudComponent } from './pages/crud/crud.component';
import {AbsencesComponent} from './pages/absences/absences.component';
import {ScheduleComponent} from './pages/schedule/schedule.component';
import {ExtracurricularsComponent} from './pages/extracurriculars/extracurriculars.component';
import {LoginComponent} from './pages/login/login.component';
import {UserDetailsComponent} from './pages/user-details/user-details.component';
import {AuthGuardService} from './pages/auth-guard.service';

const routes: Routes = [
	{
		path: '',
		canActivate: [AuthGuardService],
		component: UserDetailsComponent
	},
	{
		path: 'entrar',
		component: LoginComponent
	},
	{
		path: 'Disciplinas',
		canActivate: [AuthGuardService],
		component: CrudComponent
	},
	{
		path: 'faltas',
		canActivate: [AuthGuardService],
		component: AbsencesComponent
	},
	{
		path: 'horario-aulas',
		canActivate: [AuthGuardService],
		component: ScheduleComponent
	},
	{
		path: 'atividades-complementares',
		canActivate: [AuthGuardService],
		component: ExtracurricularsComponent
	},
	{
		path: 'registro-disciplina',
		canActivate: [AuthGuardService],
		component: CrudComponentRegister
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule {
}
