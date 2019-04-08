import { Injectable } from '@angular/core';
import {ActivatedRoute, ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {AuthToken} from '../../models/AuthToken';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private router: Router, private route: ActivatedRoute) { }

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
		if (AuthToken.isAuthenticated()) {
			return true;
		}

		this.router.navigate(['/entrar'], {
			relativeTo: this.route,
			queryParams: {
				unauthorized: true
			}
		});

		return true;
	}
}
