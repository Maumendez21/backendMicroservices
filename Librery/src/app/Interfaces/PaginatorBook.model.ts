import { Book } from './Books.model';
export interface PaginationBook{
    pagesize: number;
    page:number;
    sort: string;
    sortDirection: string;
    pagesQuantity: number;
    data: Book[];
    filterValue: {};
    totalRows: number;
}