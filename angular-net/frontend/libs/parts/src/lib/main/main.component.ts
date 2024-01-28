import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { PartsComponent } from '../parts/parts.component';

@Component({
  selector: 'frontend-main',
  standalone: true,
  imports: [CommonModule, RouterModule, PartsComponent],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css',
})
export class MainComponent {}
