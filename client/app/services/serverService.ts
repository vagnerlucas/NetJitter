import {Injectable, Inject} from '@angular/core'; 
import {Http, Response, Headers} from '@angular/http';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/share';
import {Observable} from 'rxjs/Observable';
import {Observer} from 'rxjs/Observer';
import {BaseHttpService} from './http/baseHttpService';
import {ServerModel} from '../models/serverModel';

@Injectable()
export class ServerService extends BaseHttpService {
    
    public servers: Observable<ServerModel[]>;
    private serversObserver: Observer<ServerModel[]>;
    private serverList: ServerModel[];
    
    constructor(@Inject(Http) http) {
        super(http);
        this.serverList = new Array<ServerModel>();
        this.servers = new Observable<ServerModel[]>(observer => this.serversObserver = observer).share();
    }
    
    public loadStatistics() {        
        var control = 'Server';
        var action = 'GetStatistics/';
        var url = this.serverName + control + '/' + action;
        
        this.http.get(url, {headers: this.headers})
                    .map(response => response.json())
                    .subscribe(
                        data => {
                             this.serverList = data.Data;   
                             this.serversObserver.next(this.serverList);
                        }, err => console.log('An error has occurred: ' + JSON.stringify(err)));
    }
}