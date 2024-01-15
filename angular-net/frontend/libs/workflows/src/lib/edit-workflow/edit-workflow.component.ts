import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import {
  NonNullableFormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { map, tap } from 'rxjs';

import { Workflow, WorkflowStoreService } from '../workflow-store.service';

@Component({
  selector: 'frontend-edit-workflow',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './edit-workflow.component.html',
  styleUrl: './edit-workflow.component.css',
})
export class EditWorkflowComponent {
  public workflow$ = this.route.data.pipe(
    map((data) => data['workflow'] as Workflow),
    tap((wf) => this.form.patchValue(wf))
  );

  public form = this.fb.group({
    id: [undefined as number | undefined],
    name: [
      '',
      {
        validators: [Validators.required],
      },
    ],
    description: [''],
  });

  constructor(
    private route: ActivatedRoute,
    private store: WorkflowStoreService,
    private fb: NonNullableFormBuilder
  ) {}

  public Submit() {
    if (this.form.valid) {
      const formValue = { ...{ name: '' }, ...this.form.value };
      this.store.Update(formValue);
    }
  }
}
