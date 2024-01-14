import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class WorkflowHttpClientService {
  private baseUrl = 'http://localhost:5267/';
  constructor(private http: HttpClient) {}

  public GetAll() {
    return this.http.get<Workflow_Get_DTO[]>(this.baseUrl + 'workflow');
  }

  public GetById(id: number) {
    return this.http.get<Workflow_Get_DTO>(`${this.baseUrl}workflow/${id}`);
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
}

export interface Workflow_Create_DTO {
  name: string;
}
export interface Workflow_Update_DTO {
  id: number;
  name: string;
}
