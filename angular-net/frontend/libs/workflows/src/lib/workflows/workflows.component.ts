import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkflowStoreService } from '../workflow-store.service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'frontend-workflows',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './workflows.component.html',
  styleUrl: './workflows.component.css',
})
export class WorkflowsComponent {
  public workflows$ = this.workflowStore.workflows$;

  constructor(private workflowStore: WorkflowStoreService) {}
}
