import { Injectable } from '@angular/core';
import { Author } from '../Interfaces/Author.model';
import { Subject, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AuthorsService {
  constructor(private httpClient: HttpClient) {}

  private baseURL = environment.BASE_URL;

  AuthorSubject = new Subject<Author>();
  private AuthorSubject2 = new Subject<Author[]>();

  private authorList: Author[] = [];

  // private authorList: Author[] = [
  //   {
  //     authorId: 1,
  //     name: 'Autorone',
  //     lastname: 'lastname1',
  //     degreeAcademic: 'enginier',
  //   },
  //   {
  //     authorId: 1,
  //     name: 'Autortwo',
  //     lastname: 'lastname1',
  //     degreeAcademic: 'enginier',
  //   },
  //   {
  //     authorId: 1,
  //     name: 'Autorthree',
  //     lastname: 'lastname1',
  //     degreeAcademic: 'enginier',
  //   },
  //   {
  //     authorId: 1,
  //     name: 'Autorfour',
  //     lastname: 'lastname1',
  //     degreeAcademic: 'enginier',
  //   },
  //   {
  //     authorId: 1,
  //     name: 'Autorfive',
  //     lastname: 'lastname1',
  //     degreeAcademic: 'enginier',
  //   },
  //   {
  //     authorId: 1,
  //     name: 'Autorsix',
  //     lastname: 'lastname1',
  //     degreeAcademic: 'enginier',
  //   },
  // ];

  getAuthors() {
    this.httpClient
      .get<Author[]>(`${this.baseURL}author`)
      .subscribe((data) => {
        this.authorList = data;
        this.AuthorSubject2.next([...this.authorList]);
      });
    // return this.authorList.slice();
  }

  getCurrentListener(): Observable<Author[]> {
    return this.AuthorSubject2.asObservable();
  }

  authorSave(author: Author) {
    this.authorList.push(author);
    this.AuthorSubject.next(author);
  }
}
