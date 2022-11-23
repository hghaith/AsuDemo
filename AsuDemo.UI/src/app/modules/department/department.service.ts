import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { EmptyResult, Result } from "../../../shared/models/result";
import { Department } from "./models/department";

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  controller: string = '';

  constructor(private http: HttpClient) {
    this.controller = `${environment.apiUrl}/department`
  }

  add = (department: Department): Observable<EmptyResult> => {
    return this.http.post<EmptyResult>(`${this.controller}/add`, department);
  }

  getById = (id: number): Observable<Result<Department>> => {
    return this.http.get<Result<Department>>(`${this.controller}/get-by-id/${id}`);
  }

  delete = (id: number): Observable<EmptyResult> => {
    return this.http.get<EmptyResult>(`${this.controller}/delete/${id}`);
  }

  getList = (): Observable<Result<Array<Department>>> => {
    return this.http.get<Result<Array<Department>>>(`${this.controller}/list`);
  }

}
