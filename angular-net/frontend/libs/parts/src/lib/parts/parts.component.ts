import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';

import { PartStoreService } from '@frontend/data-access';

@Component({
  selector: 'frontend-parts',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './parts.component.html',
  styleUrl: './parts.component.css',
})
export class PartsComponent {
  public parts$ = this.partflowStore.parts$;

  constructor(private partflowStore: PartStoreService) {}
}
