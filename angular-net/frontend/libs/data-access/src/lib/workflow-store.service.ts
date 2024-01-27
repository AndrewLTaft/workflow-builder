import { Injectable } from '@angular/core';
import {
  WorkflowHttpClientService,
  Workflow_Get_DTO,
} from './workflow-http-client.service';
import { BehaviorSubject, Observable, map, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WorkflowStoreService {
  private _workflows: BehaviorSubject<Workflow[]> = new BehaviorSubject(
    new Array<Workflow>()
  );

  public workflows$ = this._workflows.asObservable();

  constructor(private http: WorkflowHttpClientService) {
    this.RefreshFromSource();
  }

  public RefreshFromSource() {
    this.http.GetAll().subscribe({
      next: (workflows) => {
        this._workflows.next(workflows);
      },
    });
  }

  public ById$(id: number) {
    return this.workflows$.pipe(
      map((worflows) => worflows.find((wf) => wf.id === id))
    );
  }

  public Update(workflow: Workflow | Omit<Workflow, 'id'>) {
    let save$: Observable<Workflow_Get_DTO>;
    if ('id' in workflow && workflow.id !== undefined) {
      save$ = this.http.Update(workflow).pipe(
        tap((res) => {
          const workflows = [...this._workflows.value];
          workflows[workflows.findIndex((wf) => wf.id === res.id)] = res;
          this._workflows.next(workflows);
        })
      );
    } else {
      save$ = this.http.Create(workflow).pipe(
        tap((res) => {
          const workflows = [...this._workflows.value, res];
          this._workflows.next(workflows);
        })
      );
    }

    save$.subscribe();
  }
}

export interface Workflow {
  id: number;
  name: string;
  description?: string;
  steps: { id?: number; name: string }[];
}
