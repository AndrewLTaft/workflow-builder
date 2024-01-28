import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

import { COMMON_CONFIG_TOKEN, Config } from '@frontend/common-config';
@Injectable({
  providedIn: 'root',
})
export class PartHttpClientService {
  private baseUrl = this.config.apiBaseURL;
  constructor(
    private http: HttpClient,
    @Inject(COMMON_CONFIG_TOKEN) private config: Config
  ) {}

  public GetAll() {
    return this.http.get<Part_Get_DTO[]>(this.baseUrl + 'part');
  }

  public Create(workflowId: number) {
    return this.http.post<Part_Get_DTO>(this.baseUrl + 'part', {
      workflowId: workflowId,
    });
  }

  public CompleteStep(partId: number) {
    return this.http.patch<Part_Get_DTO>(
      this.baseUrl + 'part/' + partId + '/completestep',
      {}
    );
  }
}
export interface Part_Get_DTO {
  id: number;
  workflowId: number;
  createdAt: string;
  completed: boolean;
  stepId?: string;
}
