import {Component, OnInit, Injectable, Inject, ElementRef, AfterViewChecked} from '@angular/core';
import {FORM_DIRECTIVES} from '@angular/common';
import {AsyncPipe} from '@angular/common';
import {Observable} from 'rxjs/Rx';
import {Http} from '@angular/http';
import {ROUTER_DIRECTIVES, Router, RouteParams, RouteConfig} from '@angular/router-deprecated';
import {ServerModel} from '../models/serverModel';
import {ServerService} from '../services/serverService';

@Component({
    templateUrl: 'app/templates/server-template.html',
    styles: [`td.content { padding: 0 10px 17px 10px; vertical-align: bottom; }`],
    providers: [ServerService]
})

export class ServerComponent implements OnInit {
    
    selectedInterval: string;
    private worker: any;
    public serverStatsList: Observable<ServerModel[]>;
    
    constructor(@Inject(Http) private http: Http, private serverService: ServerService, private _router: Router, private elementRef: ElementRef) {
        this.selectedInterval = "5";
     }
    
    public ngOnInit() {
        this.serverStatsList = this.serverService.servers;
        this.worker = setInterval(() => { this.processStats() }, +this.selectedInterval * 1000);
     }
     
     public onSelectChange(interval) {
         this.selectedInterval = interval;
     }
     
     private processStats() {
        // this.serverStatsList.subscribe(l => console.log(l));
        this.serverService.loadStatistics();
    }
    
}