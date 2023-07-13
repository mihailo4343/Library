import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { BookClient } from "./libraryClient";

@NgModule({
    imports: [CommonModule],
    providers: [
        BookClient
    ]
})
export class LibraryClientModule{}