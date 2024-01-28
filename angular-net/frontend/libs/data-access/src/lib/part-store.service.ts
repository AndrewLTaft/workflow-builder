import { Injectable } from '@angular/core';
import { PartHttpClientService } from './part-http-client.service';
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
        this._parts.next(parts);
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
          const parts = [...this._parts.value, res];
          this._parts.next(parts);
        })
      )
      .subscribe();
  }
}

export interface Part {
  id: number;
  workflowId: number;
}
