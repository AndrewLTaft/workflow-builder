import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PartStoreService, WorkflowStoreService } from '@frontend/data-access';
import {
  NonNullableFormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'frontend-new-part',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './new-part.component.html',
  styleUrl: './new-part.component.css',
})
export class NewPartComponent {
  public _workflows$ = this.workflowStore.workflows$;
  public form = this.fb.group({
    workflowId: [undefined as number | undefined, [Validators.required]],
  });

  constructor(
    private partStore: PartStoreService,
    private workflowStore: WorkflowStoreService,
    private fb: NonNullableFormBuilder
  ) {}

  public Submit() {
    if (this.form.valid) {
      this.partStore.Create(this.form.value.workflowId!);
    }
  }
}
