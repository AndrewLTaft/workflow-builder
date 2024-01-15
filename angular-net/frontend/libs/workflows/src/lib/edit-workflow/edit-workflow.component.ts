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
    tap((wf) => {
      this.form.patchValue(wf);
      this.form.controls.steps.clear();
      wf.steps?.forEach((s) => {
        const newGroup = this.fb.group({
          id: [undefined as number | undefined],
          name: [
            s.name,
            {
              validators: [Validators.required],
            },
          ],
        });
        this.form.controls.steps.push(newGroup);
      });
    })
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
    steps: this.fb.array([
      this.fb.group({
        id: [undefined as number | undefined],
        name: [
          '',
          {
            validators: [Validators.required],
          },
        ],
      }),
    ]),
  });

  constructor(
    private route: ActivatedRoute,
    private store: WorkflowStoreService,
    private fb: NonNullableFormBuilder
  ) {}

  get formSteps() {
    return this.form.controls['steps'];
  }
  public AddStep() {
    const stepForm = this.fb.group({
      id: [undefined as number | undefined],
      name: [
        '',
        {
          validators: [Validators.required],
        },
      ],
    });

    this.formSteps.push(stepForm);
  }

  public RemoveStep(i: number) {
    this.formSteps.removeAt(i);
  }

  public MoveUp(i: number) {
    const tmp = this.formSteps.at(i - 1);
    this.formSteps.setControl(i - 1, this.formSteps.at(i));
    this.formSteps.setControl(i, tmp);
  }

  public MoveDown(i: number) {
    const tmp = this.formSteps.at(i + 1);
    this.formSteps.setControl(i + 1, this.formSteps.at(i));
    this.formSteps.setControl(i, tmp);
  }

  public Submit() {
    if (this.form.valid) {
      this.store.Update(this.form.getRawValue());
    }
  }
}
