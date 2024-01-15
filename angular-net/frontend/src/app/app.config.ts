import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';

import { COMMON_CONFIG_TOKEN, Config } from '@frontend/common-config';

import { appRoutes } from './app.routes';

export const APP_CONFIG: Config = {
  apiBaseURL: 'http://localhost:5267/',
};

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(appRoutes),
    provideHttpClient(),
    { provide: COMMON_CONFIG_TOKEN, useValue: APP_CONFIG },
  ],
};
