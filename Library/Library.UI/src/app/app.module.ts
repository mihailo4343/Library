import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {GridComponent} from 'src/libs/components/grid/grid.component';
import {AgGridModule} from 'ag-grid-angular';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {LibraryClientModule} from 'src/libs/data-access/library.module';
import {HttpClientModule} from '@angular/common/http';
import {API_BASE_URL} from 'src/libs/data-access/libraryClient';
import {getBaseApiUrl} from 'src/libs/functions/get-base-api-url';
import {ActionCellRendererComponent} from "../libs/components/grid/action-cell-renderer/action-cell-renderes";
import {DialogFormComponent} from "../libs/components/dialog/dialog-form.component";
import {MatDialogModule} from "@angular/material/dialog";
import {MatFormFieldModule} from "@angular/material/form-field";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatNativeDateModule} from "@angular/material/core";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {ToastrModule} from "ngx-toastr";

@NgModule({
  declarations: [
    AppComponent,
    GridComponent,
    ActionCellRendererComponent,
    DialogFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AgGridModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    LibraryClientModule,
    HttpClientModule,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useFactory: getBaseApiUrl
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
