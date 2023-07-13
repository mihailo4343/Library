import {Injectable, OnDestroy} from "@angular/core";
import {BookClient, BookModel} from "src/libs/data-access/libraryClient";
import {Observable, take, tap} from "rxjs";

@Injectable({
  providedIn: "root"
})

export class BookService {
  constructor(readonly bookClient: BookClient) {
  }

  public getAllBooks(): Observable<BookModel[]> {
    return this.bookClient.getAllBooks();
  }

  public createBook(model: BookModel): Observable<void> {
    return this.bookClient.createBook(model);
  }

  public updateBook(model: BookModel): Observable<void> {
    return this.bookClient.updateBook(model);
  }

  public deleteBook(model: BookModel): Observable<void> {
    return this.bookClient.deleteBook(model);
  }
}
