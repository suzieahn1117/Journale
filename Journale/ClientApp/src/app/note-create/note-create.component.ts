import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

interface Note {
  id: string;
  content: string;
  createdDate: string;
}


@Component({
  selector: 'app-note-create',
  templateUrl: './note-create.component.html',
  styleUrls: ['./note-create.component.css']
})

export class NoteCreateComponent implements OnInit, AfterViewInit {
  note: Note;

  constructor(public http: HttpClient, private router: Router) {
    this.note =
      {
        id: '',
        content: '',
        createdDate: new Date().toISOString()
      } as Note;

  }

  public CreateNote() {
    var onSuccess = (result) => {
      this.router.navigateByUrl('/');  
    }
    var onError = (result) => {
      console.log(result);
    }

    this.http.post('/api/notes', this.note).toPromise()
      .then(res => onSuccess(res))
      .catch(onError);
  }

  ngOnInit() {

  }


  ngAfterViewInit() {

  }

}
