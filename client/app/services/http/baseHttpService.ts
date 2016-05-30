import {Injectable, Inject} from '@angular/core'; 
import {Http, Response, Headers} from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class BaseHttpService {
     protected serverName = 'http://localhost:5999/';
     protected headers = new Headers();

    constructor(@Inject(Http) protected http: Http) {
        this.http = http;
    }
}