import {bootstrap}  from '@angular/platform-browser-dynamic';
import {bind, provide} from '@angular/core';
import {HTTP_PROVIDERS} from '@angular/http';
import {RouteConfig, ROUTER_PROVIDERS, ROUTER_DIRECTIVES} from '@angular/router-deprecated';
import {AppComponent} from './components/app.component';

bootstrap(AppComponent, [HTTP_PROVIDERS, ROUTER_PROVIDERS, ROUTER_DIRECTIVES]);