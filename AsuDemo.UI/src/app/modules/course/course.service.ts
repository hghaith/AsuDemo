import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { EmptyResult, Result } from "../../../shared/models/result";
import { Course } from "./models/course";

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  controller: string = '';

  constructor(private http: HttpClient) {
    this.controller = `${environment.apiUrl}/course`
  }

  add = (course: Course): Observable<EmptyResult> => {
    return this.http.post<EmptyResult>(`${this.controller}/add`, course);
  }

  getById = (id: number): Observable<Result<Course>> => {
    return this.http.get<Result<Course>>(`${this.controller}/get-by-id/${id}`);
  }

  delete = (id: number): Observable<EmptyResult> => {
    return this.http.get<EmptyResult>(`${this.controller}/delete/${id}`);
  }

  getList = (): Observable<Result<Array<Course>>> => {
    return this.http.get<Result<Array<Course>>>(`${this.controller}/list`);
  }

}
