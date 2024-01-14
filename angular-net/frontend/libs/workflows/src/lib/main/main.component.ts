import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkflowsComponent } from '../workflows/workflows.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'frontend-main',
  standalone: true,
  imports: [CommonModule, WorkflowsComponent, RouterModule],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css',
})
export class MainComponent {}
