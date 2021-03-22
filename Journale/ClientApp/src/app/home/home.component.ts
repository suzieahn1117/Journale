import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

interface Note {
  id: string,
  content: string,
  createdDate: string
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent {
  notes: Note[];

  constructor(private http: HttpClient, private router: Router) {

  }

  public GetNotes() {
    this.http.get<Note[]>('api/notes').toPromise().then(result =>
      this.notes = result
      );
  }

  public RedirectToNoteDetail(id) {
    this.router.navigateByUrl('note-detail/' + id);
  }

  ngOnInit() {
    this.GetNotes();
  }

}

