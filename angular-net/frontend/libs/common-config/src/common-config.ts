import { InjectionToken } from '@angular/core';

export const COMMON_CONFIG_TOKEN = new InjectionToken<Config>('config');

export interface Config {
  apiBaseURL: string;
}
