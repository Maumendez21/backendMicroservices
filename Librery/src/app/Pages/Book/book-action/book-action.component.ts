import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatOption } from '@angular/material/core';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatSelectChange } from '@angular/material/select';
import { BookService } from '../../../Services/book.service';
import { Book } from '../../../Interfaces/Books.model';
import { Subscription } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { Author } from '../../../Interfaces/Author.model';
import { AuthorsService } from '../../../Services/authors.service';

@Component({
  selector: 'app-book-action',
  templateUrl: './book-action.component.html',
  styleUrls: ['./book-action.component.css'],
})
export class BookActionComponent implements OnInit {


  private authorSubcription!: Subscription;

  constructor(
    private fb: FormBuilder,
    private booService: BookService,
    private dialogRef: MatDialog,
    private authorService: AuthorsService
  ) {}

  @ViewChild(MatDatepicker) picker!: MatDatepicker<Date>;

  public selectedAutorText: string = '';
  public authors: Author[] = [];

  public bookForm = this.fb.group({
    title: ['', [Validators.required]],
    description: ['', [Validators.required]],
    price: [0, [Validators.required]],
    autor: ['', [Validators.required]],
    datePublication: [''],
  });

  ngOnInit(): void {
    this.authorService.getAuthors();
    this.authorSubcription = this.authorService.getCurrentListener().subscribe((response: Author[]) => {
      this.authors = response;
      console.log(this.authors);
      
    });
  }

  selected(event: MatSelectChange) {

    // console.log(event.source.selected);
    
    
    this.selectedAutorText = (event.source.selected as MatOption).viewValue;
  }

  submit() {
    if (!this.bookForm.valid) {
      return;
    }

    const authorRequest = {
      id: this.bookForm.value.autor || '',
      nameComplet: this.selectedAutorText 
    }

    let dateFinally: string = this.bookForm.value.datePublication || '';
    let newBook: any = {
      title: this.bookForm.value.title || '',
      description: this.bookForm.value.description || '',
      autor: authorRequest,
      price: this.bookForm.value.price || 0,
      publicationDate: new Date(dateFinally),
    };


    console.log(newBook);
    

    this.booService.bookSave(newBook);
    this.booService.saveBookListener()
    .subscribe((response) => {
      this.dialogRef.closeAll();

    })
  }

  ngOnDestroy(): void {
    //Called once, before the instance is destroyed.
    //Add 'implements OnDestroy' to the class.
    this.authorSubcription.unsubscribe();
  }
}
