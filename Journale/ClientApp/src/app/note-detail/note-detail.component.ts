import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

interface Note {
  id: string,
  content: string,
  createdDate: string
}


@Component({
  selector: 'app-note-detail',
  templateUrl: './note-detail.component.html',
  styleUrls: ['./note-detail.component.css']
})

export class NoteDetailComponent implements OnInit {
  id: string
  note: Note

  constructor(private http: HttpClient, private router: Router, private activatedRouter: ActivatedRoute) {
    this.note = {
      id: this.id,
      content: '',
      createdDate: ''
    } as Note;


    this.activatedRouter.paramMap.subscribe((params: ParamMap) => {
      this.id = params.get('id')
      this.note.id = this.id
      this.GetNoteDetail(this.id);
    })


  }

  public GetNoteDetail(id) {
    this.http.get<Note>('api/notes/' + id).toPromise().then(
      result => this.note = result)
  }

  public SaveNote() {
    this.http.put('api/notes/' + this.note.id, this.note).toPromise().then(
      result => this.router.navigateByUrl('/')
    )
  }

  public DeleteNote() {
    this.http.delete('api/notes/' + this.note.id).toPromise().then(
      result => this.router.navigateByUrl('/')
    )
  }

  ngOnInit() {
  }

}
