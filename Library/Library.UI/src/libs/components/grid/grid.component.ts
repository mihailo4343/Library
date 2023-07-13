import {Component, OnInit, ViewChild} from '@angular/core';
import {ColDef, GridOptions} from 'ag-grid-community';
import {Observable, take} from 'rxjs';
import {BookModel, IBookModel} from 'src/libs/data-access/libraryClient';
import {BookService} from 'src/libs/services/book.service';
import {ActionCellRendererComponent} from "./action-cell-renderer/action-cell-renderes";
import {AgGridAngular} from "ag-grid-angular";
import {MatDialog} from "@angular/material/dialog";
import {DialogFormComponent} from "../dialog/dialog-form.component";
import {ToastrService} from 'ngx-toastr';
import {DialogFormData} from "../dialog/dialog-form-data.interface";
import * as moment from "moment";
import {ActionMode} from "../dialog/action-mode.enum";

@Component({
  selector: 'overview-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit {
  gridOptions!: GridOptions;
  public rowData$!: Observable<BookModel[]>;
  public columnDefs: ColDef[] = [
    {headerName: 'Title', field: 'title'},
    {headerName: 'Author', field: 'author'},
    {headerName: 'ISBN', field: 'isbn'},
    {headerName: 'Publisher', field: 'publisher'},
    {
      headerName: 'Publication Date', field: 'publicationDate', valueFormatter: ({value}) => {
        if (value) {
          return moment(value).format('l');
        }
        return '';
      },
    },
    {headerName: 'Genre', field: 'genre'},
    {headerName: 'Page Count', field: 'pageCount'},
    {headerName: 'Description', field: 'description', suppressSizeToFit: true},
    {
      headerName: 'Actions',
      field: 'actions',
      cellRenderer: ActionCellRendererComponent,
      cellRendererParams: {
        onEdit: this.onEdit.bind(this),
        onDelete: this.onDelete.bind(this)
      }
    }
  ];


  @ViewChild('bookGrid', {static: true}) private bookGrid!: AgGridAngular;

  constructor(
    private readonly bookService: BookService,
    private readonly dialog: MatDialog,
    private readonly toasterService: ToastrService
  ) {
  }

  ngOnInit(): void {
    this.rowData$ = this.bookService.getAllBooks();
    this.gridOptions = {
      onGridReady: this.onGridReady.bind(this)
    } as GridOptions;
  }

  private onGridReady(params: any): void {
    params.api.sizeColumnsToFit();
  }

  private onEdit(book: BookModel): void {
    this.openDialog(book, ActionMode.Edit);
  }

  private onDelete(book: BookModel): void {
    this.bookService.deleteBook(book).pipe(take(1)).subscribe(model => {
      this.bookGrid.api.applyTransaction({remove: [book]});
      this.toasterService.success('Book deleted successfully.', 'Success');
    });
  }

  public onCreate(): void {
    this.openDialog(undefined, ActionMode.Create);
  }

  private openDialog(book: BookModel | undefined, mode: ActionMode): void {
    const dialogData: DialogFormData = {
      book: book ? book : undefined,
      mode: mode
    };

    const dialogRef = this.dialog.open(DialogFormComponent, {
      width: '600px', height: '1000px',
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (mode === ActionMode.Create) {
          this.createBook(result);
        } else if (mode === ActionMode.Edit) {
          this.editBook(result);
        }
      }
    });
  }

  private createBook(formData: BookModel): void {
    this.bookService.createBook(formData).pipe(take(1)).subscribe(() => {
      formData.pageCount ? formData.pageCount = +formData.pageCount : null;
      formData.isbn = +formData.isbn;
      this.bookGrid.api.applyTransaction({add: [formData]});
      this.toasterService.success('Book created successfully.', 'Success');
    });
  }

  private editBook(formData: BookModel): void {
    const matchingBook = this.bookGrid.rowData?.find((book: BookModel) => book.isbn === formData.isbn);
    this.bookService.updateBook(formData).pipe(take(1)).subscribe(() => {
      if (matchingBook) {
        formData.pageCount ? formData.pageCount = +formData.pageCount : null;
        Object.assign(matchingBook, formData);
        this.bookGrid.api.applyTransaction({update: [matchingBook]});
        this.toasterService.success('Book updated successfully.', 'Success');
      }
    });
  }

}
