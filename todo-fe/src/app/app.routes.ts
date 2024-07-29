import { Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';

export const routes: Routes = [
    { path: 'login', component: LoginPageComponent },
    //{ path: 'not-found', component: PageNotFoundComponent },
    { path: '**', redirectTo: '/not-found' }
];
