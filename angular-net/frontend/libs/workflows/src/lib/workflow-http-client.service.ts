import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { COMMON_CONFIG_TOKEN, Config } from '@frontend/common-config';
@Injectable({
  providedIn: 'root',
})
export class WorkflowHttpClientService {
  private baseUrl = this.config.apiBaseURL;
  constructor(
    private http: HttpClient,
    @Inject(COMMON_CONFIG_TOKEN) private config: Config
  ) {}

  public GetAll() {
    return this.http.get<Workflow_Get_DTO[]>(this.baseUrl + 'workflow');
  }

  public Create(model: Workflow_Create_DTO) {
    return this.http.post<Workflow_Get_DTO>(`${this.baseUrl}workflow`, model);
  }

  public Update(model: Workflow_Update_DTO) {
    return this.http.put<Workflow_Get_DTO>(`${this.baseUrl}workflow`, model);
  }
}

export interface Workflow_Get_DTO {
  id: number;
  name: string;
  description?: string;
  steps: { id: number; name: string }[];
}

export interface Workflow_Create_DTO {
  name: string;
  description?: string;
  steps: { name: string }[];
}
export interface Workflow_Update_DTO {
  id: number;
  name: string;
  description?: string;
  steps: { id?: number; name: string }[];
}
