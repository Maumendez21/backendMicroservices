import { Injectable } from '@angular/core';
import { Book } from '../Interfaces/Books.model';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { PaginationBook } from '../Interfaces/PaginatorBook.model';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  bookSubject = new Subject();
  bookPaginatorSubject = new Subject<PaginationBook>();

  private baseURL = environment.BASE_URL;

  // private bookList: Book[] = [
  //   {
  //     bookId: 1,
  //     title: 'Algoritmo',
  //     description: 'Libro de allgoritmos',
  //     autor: 'Vaxi Perez',
  //     price: 30,
  //   },
  //   {
  //     bookId: 2,
  //     title: 'Algoritmo',
  //     description: 'Libro de allgoritmos',
  //     autor: 'Vaxi Perez',
  //     price: 20,
  //   },
  //   {
  //     bookId: 3,
  //     title: 'Algoritmo',
  //     description: 'Libro de allgoritmos',
  //     autor: 'Vaxi Perez',
  //     price: 40,
  //   },
  //   {
  //     bookId: 4,
  //     title: 'Algoritmo',
  //     description: 'Libro de allgoritmos',
  //     autor: 'Vaxi Perez',
  //     price: 50,
  //   },
  //   {
  //     bookId: 4,
  //     title: 'Algoritmo',
  //     description: 'Libro de allgoritmos',
  //     autor: 'Vaxi Perez',
  //     price: 50,
  //   },
  //   {
  //     bookId: 4,
  //     title: 'Algoritmo',
  //     description: 'Libro de allgoritmos',
  //     autor: 'Vaxi Perez',
  //     price: 50,
  //   },
  //   {
  //     bookId: 4,
  //     title: 'Algoritmo',
  //     description: 'Libro de allgoritmos',
  //     autor: 'Vaxi Perez',
  //     price: 50,
  //   },
  // ];

  private bookPagination!: PaginationBook;
  private bookList: Book[] = [];
  constructor(private httpClient: HttpClient) {}



  getBooks(bookForPage: number, pageCurrent: number, Sort: string, SortDirection: string, FilterValue: any) {
    const request = {
      PageSize: bookForPage,
      Page: pageCurrent,
      Sort,
      SortDirection,
      FilterValue,
    };


    this.httpClient.post<PaginationBook>(`${this.baseURL}book/pagination`, request)
    .subscribe((data) => {
      this.bookPagination = data;
      this.bookPaginatorSubject.next(this.bookPagination);
    })


  }


  getCurrentListener(){
    return this.bookPaginatorSubject.asObservable();
  }

  bookSave(book: Book) {



    this.httpClient.post(`${this.baseURL}book`,  book)
    .subscribe((response) => {
      this.bookSubject.next(null);
    })

    
  }


  saveBookListener(){
    return this.bookSubject.asObservable();
  }
}
