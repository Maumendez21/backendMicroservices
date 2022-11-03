import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthorsService } from '../../Services/authors.service';
import { MatDialog } from '@angular/material/dialog';
import { Author } from '../../Interfaces/Author.model';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { AutorActionComponent } from './autor-action/autor-action.component';

@Component({
  selector: 'app-autor',
  templateUrl: './autor.component.html',
  styleUrls: ['./autor.component.css'],
})
export class AutorComponent implements OnInit {
  constructor(
    private authorService: AuthorsService,
    private dialog: MatDialog
  ) {}

  public displayedColumns = ['name', 'lastname', 'degreeAcademic'];
  public dataSource = new MatTableDataSource<Author>();
  private authorSubscription!: Subscription;
  @ViewChild(MatSort) order!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    // this.dataSource.data = this.authorService.getAuthors();
    this.authorService.getAuthors();

    this.authorSubscription = this.authorService
      .getCurrentListener()
      .subscribe((authors) => {
        this.dataSource.data = authors;
      });


    // this.authorSubscription = this.authorService.AuthorSubject.subscribe(() => {
    //   this.dataSource.data = this.authorService.getAuthors();
    // });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.order;
    this.dataSource.paginator = this.paginator;
  }

  filter(filterValue: any) {
    this.dataSource.filter = filterValue.value;
  }

  openModal() {
    this.dialog.open(AutorActionComponent, {
      width: '350px',
      disableClose: true,
    });
  }

  ngOnDestroy(): void {
    this.authorSubscription.unsubscribe();
  }
}
