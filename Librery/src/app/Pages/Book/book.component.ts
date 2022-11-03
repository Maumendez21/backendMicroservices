import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { BookService } from 'src/app/Services/book.service';
import { Book } from '../../Interfaces/Books.model';
import { BookActionComponent } from './book-action/book-action.component';
import { Subscription } from 'rxjs';
import { PaginationBook } from 'src/app/Interfaces/PaginatorBook.model';

const element_data: Book[] = [];

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
})
export class BookComponent implements OnInit {
  constructor(private bookService: BookService, private dialog: MatDialog) {}

  displayedColumns = ['title', 'description', 'autor', 'price'];
  public dataSource = new MatTableDataSource<Book>();
  private bookSubscription!: Subscription;

  timeout: any = null;
  @ViewChild(MatSort) order!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  public bookTotals = 0;
  public booksForPage = 2;
  public pageCombo = [1, 2, 5, 10];
  public pageCurrent = 1;
  public sort = 'title';
  public sortDirection = 'asc';
  public filterValue = null;

  ngOnInit(): void {
    // this.dataSource.data = this.bookService.getBooks();
    // this.bookSubscription = this.bookService.bookSubject.subscribe(() => {
    //   this.dataSource.data = this.bookService.getBooks();
    // });

    this.loadData();
  }

  loadData() {
    this.bookService.getBooks(
      this.booksForPage,
      this.pageCurrent,
      this.sort,
      this.sortDirection,
      this.filterValue
    );
    this.bookService.getCurrentListener().subscribe((data: PaginationBook) => {
      this.dataSource.data = data.data;
      this.bookTotals = data.totalRows;
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.order;
    this.dataSource.paginator = this.paginator;
  }

  filter(event: any) {
    clearTimeout(this.timeout);

    var $this = this;
    this.timeout = setTimeout(() => {
      if (event.keyCode != 13) {
        const FilterValue = {
          property: 'title',
          value: event.target.value,
        };

        $this.bookService.getBooks(
          $this.booksForPage,
          $this.pageCurrent,
          $this.sort,
          $this.sortDirection,
          FilterValue
        );
      }
    }, 1000);
  }

  openModal() {
    const dialogref = this.dialog.open(BookActionComponent, {
      width: '550px',
      disableClose: true,
    });

    dialogref.afterClosed().subscribe(() => {
      this.bookService.getBooks(
        this.booksForPage,
        this.pageCurrent,
        this.sort,
        this.sortDirection,
        this.filterValue
      );
    });
  }

  eventPaginator(event: PageEvent) {
    this.booksForPage = event.pageSize;
    this.pageCurrent = event.pageIndex + 1;
    this.bookService.getBooks(
      this.booksForPage,
      this.pageCurrent,
      this.sort,
      this.sortDirection,
      this.filterValue
    );
  }

  orderColumns(event: any) {
    this.sort = event.active;
    this.sortDirection = event.direction;
    this.bookService.getBooks(
      this.booksForPage,
      this.pageCurrent,
      event.active,
      event.direction,
      this.filterValue
    );
  }

  ngOnDestroy(): void {
    this.bookSubscription.unsubscribe();
  }

  







  
}
