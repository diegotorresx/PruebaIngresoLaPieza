import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StudentModel } from './student.model'; // Asegúrate de definir un modelo que coincida con tu backend

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private apiUrl = 'https://localhost:7234';

  constructor(private http: HttpClient) { }

  getStudents() {
    return this.http.get<StudentModel[]>(`${this.apiUrl}/Students`);
  }

  getStudentById(id: number) {
    return this.http.get<StudentModel>(`${this.apiUrl}/Students/${id}`);
  }

  createStudent(student: StudentModel) {
    return this.http.post(`${this.apiUrl}/Students`, student);
  }

  updateStudent(student: StudentModel) {
    return this.http.put(`${this.apiUrl}/Students`, student);
  }

  deleteStudent(id: number) {
    return this.http.delete(`${this.apiUrl}/Students/${id}`);
  }
}