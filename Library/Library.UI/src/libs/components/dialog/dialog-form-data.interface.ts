import {IBookModel} from "../../data-access/libraryClient";
import {ActionMode} from "./action-mode.enum";

export interface DialogFormData {
  mode: ActionMode;
  book?: IBookModel;
}
