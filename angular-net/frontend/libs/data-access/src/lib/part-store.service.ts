import { Injectable } from '@angular/core';
import {
  PartHttpClientService,
  Part_Get_DTO,
} from './part-http-client.service';
import { BehaviorSubject, map, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PartStoreService {
  private _parts: BehaviorSubject<Part[]> = new BehaviorSubject(
    new Array<Part>()
  );

  public parts$ = this._parts.asObservable();

  constructor(private http: PartHttpClientService) {
    this.RefreshFromSource();
  }

  public RefreshFromSource() {
    this.http.GetAll().subscribe({
      next: (parts) => {
        const converted = parts.map(this.convertPartDto);
        this._parts.next(converted);
      },
    });
  }

  public ById$(id: number) {
    return this.parts$.pipe(
      map((parts) => parts.find((part) => part.id === id))
    );
  }

  public Create(workflowId: number) {
    this.http
      .Create(workflowId)
      .pipe(
        tap((res) => {
          const parts = [...this._parts.value, this.convertPartDto(res)];
          this._parts.next(parts);
        })
      )
      .subscribe();
  }

  public CompleteStep(part: Part) {
    this.http
      .CompleteStep(part.id)
      .pipe(
        tap((res) => {
          const parts = [...this._parts.value];
          parts[parts.findIndex((p) => p.id === res.id)] =
            this.convertPartDto(res);
          this._parts.next(parts);
        })
      )
      .subscribe();
  }

  private convertPartDto(dto: Part_Get_DTO): Part {
    return { ...dto, createdAt: new Date(dto.createdAt) };
  }
}

export interface Part {
  id: number;
  workflowId: number;
  createdAt: Date;
  completed: boolean;
  stepId?: string;
}
