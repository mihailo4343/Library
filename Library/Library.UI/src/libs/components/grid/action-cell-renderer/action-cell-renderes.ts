import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'action-cell-renderer',
  templateUrl: './action-cell-renderer.html'
})
export class ActionCellRendererComponent implements ICellRendererAngularComp {
  private params: any;

  public agInit(params: any): void {
    this.params = params;
  }

  public refresh(): boolean {
    return false;
  }

  public edit(): void {
    this.params.onEdit(this.params.data);
  }

  public delete(): void {
    this.params.onDelete(this.params.data);
  }
}
