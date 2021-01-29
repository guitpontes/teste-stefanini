import { Component } from '@angular/core';

export type EditorType = 'insert' | 'edit' | 'delete';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  editor: EditorType = 'insert';

  get showInsert() {
    return this.editor === 'insert';
  }

  get showEdit() {
    return this.editor === 'edit';
  }

  get showDelete() {
    return this.editor === 'delete';
  }

  toggleEditor(type: EditorType) {
    this.editor = type;
  }
}
