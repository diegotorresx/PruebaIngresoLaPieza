import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { StudentService } from '../student.service';
import { StudentModel } from '../student.model';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  
  studentsForms: FormGroup[] = [];
  displayedColumns: string[] = ['username', 'firstName', 'lastName', 'age', 'career', 'actions'];
  dataSource = new MatTableDataSource<StudentModel>([]);
  
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  constructor(private studentService: StudentService, private fb: FormBuilder) { }

  ngOnInit(): void {
    
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getStudents().subscribe((students: StudentModel[]) => {
      this.studentsForms = students.map((student: StudentModel) => this.toFormGroup(student));
      this.dataSource = new MatTableDataSource(students);
      this.dataSource.sort = this.sort;
      

      // Añade una fila vacía al final para nuevos registros
      this.studentsForms.push(this.toFormGroup({} as StudentModel));
    });
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  toFormGroup(student: StudentModel): FormGroup {
    return this.fb.group({
      id: [student.id],
      username: [student.username, Validators.required],
      firstName: [student.firstName, Validators.required],
      lastName: [student.lastName, Validators.required],
      age: [student.age, Validators.required],
      career: [student.career, Validators.required]
    });
  }

  save(form: FormGroup) {
    console.log(form.value); // Agrega esto para ver los valores del formulario
    console.log(form.valid);
    const student: StudentModel = form.value;
    if (student.id) {
      this.studentService.updateStudent(student).subscribe(() => this.loadStudents());
    } else {
      this.studentService.createStudent(student).subscribe(() => this.loadStudents());
    }
  }

  delete(id: number) {
    this.studentService.deleteStudent(id).subscribe(() => this.loadStudents());
  }
}