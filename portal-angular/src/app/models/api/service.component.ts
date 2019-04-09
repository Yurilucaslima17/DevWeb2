import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {User} from '../User';

export class ServiceComponent {
	constructor(private http: HttpClient){}
	public getUsers(list: Array<User>){
		return this.http.get('https://172.17.105.253:44322/api/GetUsers')
		.subscribe((data) => {
			list = [data as User];
		})
	}
}
