import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  controller: string = '';

  constructor(private http: HttpClient) {
    this.controller = `${environment.apiUrl}/department`
  }

  getList = (): Observable<any> => {
    return this.http.get(`${this.controller}/list`);
  }

}
