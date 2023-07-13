import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {DialogFormData} from './dialog-form-data.interface';
import {ActionMode} from "./action-mode.enum";

@Component({
  selector: 'dialog-form',
  templateUrl: './dialog-form.component.html'
})
export class DialogFormComponent implements OnInit {
  bookForm!: FormGroup;
  mode!: ActionMode.Create | ActionMode.Edit;
  formError: string | null = null;

  constructor(
    private dialogRef: MatDialogRef<DialogFormComponent>,
    @Inject(MAT_DIALOG_DATA) private data: DialogFormData,
    private formBuilder: FormBuilder
  ) {
    this.mode = data.mode;
  }

  ngOnInit(): void {
    this.initForm();
    if (this.data.book) {
      this.populateForm(this.data.book);
    }
  }

  initForm(): void {
    this.bookForm = this.formBuilder.group({
      isbn: ['', [Validators.required, Validators.pattern(/^\d{13}$/)]],
      title: ['', Validators.required],
      author: ['', Validators.required],
      publisher: ['', Validators.maxLength(100)],
      publicationDate: [null],
      genre: ['', Validators.maxLength(50)],
      pageCount: [null, Validators.min(1)],
      description: ['', Validators.maxLength(500)]
    });
  }

  public isCreateForm(): boolean{
    return this.mode === ActionMode.Create;
  }

  private populateForm(book: any): void {
    const { publicationDate, ...otherData } = book;
    const formattedPublicationDate = publicationDate ? new Date(publicationDate) : null;

    this.bookForm.patchValue({ ...otherData, publicationDate: formattedPublicationDate });
  }


  public getErrorMessage(controlName: string): string {
    const control = this.bookForm.get(controlName);
    if (control?.hasError('required')) {
      return 'This field is required.';
    } else if (control?.hasError('pattern')) {
      return 'Invalid format.';
    } else if (control?.hasError('maxLength')) {
      return 'Exceeded maximum length.';
    } else if (control?.hasError('min')) {
      return 'Value must be greater than zero.';
    }
    return '';
  }

  public onSubmit(): void {
    if (this.bookForm.valid) {
      const formData = this.bookForm.value;
      this.formError = null;
      this.dialogRef.close(formData);
    } else {
      this.formError = 'Please correct the errors in the form.';
    }
  }

  public onCancel(): void {
    this.dialogRef.close();
  }
}
