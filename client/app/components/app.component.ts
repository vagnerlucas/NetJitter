import {Component} from '@angular/core';
import {RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from '@angular/router-deprecated';
import {ServerComponent} from './server.component';

@Component({
    selector: 'main-app',
    templateUrl: 'app/templates/app-template.html',
    directives: [ROUTER_DIRECTIVES],
    providers: [ServerComponent]
})

@RouteConfig([
    { path: '/', component: ServerComponent, name: 'Server' },
])

export class AppComponent {}