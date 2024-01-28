import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { filter, map, switchMap } from 'rxjs';

import {
  Part,
  PartStoreService,
  WorkflowStoreService,
} from '@frontend/data-access';

@Component({
  selector: 'frontend-edit-part',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './edit-part.component.html',
  styleUrl: './edit-part.component.css',
})
export class EditPartComponent {
  public viewModel$ = this.route.data.pipe(
    map((data) => data['part'] as Part),
    switchMap((part) => {
      return this.workflowStore.ById$(part.workflowId).pipe(
        filter((wf) => wf !== undefined),
        map((wf) => ({
          part: part,
          workflowName: wf!.name,
          stepName: wf!.steps.find((s) => s.id === part.stepId)?.name,
        }))
      );
    })
    // tap((wf) => {
    //   this.form.patchValue(wf);
    //   this.form.controls.steps.clear();
    //   wf.steps?.forEach((s) => {
    //     const newGroup = this.fb.group({
    //       id: [undefined as number | undefined],
    //       name: [
    //         s.name,
    //         {
    //           validators: [Validators.required],
    //         },
    //       ],
    //     });
    //     this.form.controls.steps.push(newGroup);
    //   });
    // })
  );

  constructor(
    private route: ActivatedRoute,
    private partStore: PartStoreService,
    private workflowStore: WorkflowStoreService
  ) {}

  public nextStep(part: Part) {
    this.partStore.CompleteStep(part);
  }
}
