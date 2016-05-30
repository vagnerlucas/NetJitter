"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
require('rxjs/add/observable/throw');
require('rxjs/add/operator/catch');
require('rxjs/add/operator/debounceTime');
require('rxjs/add/operator/distinctUntilChanged');
require('rxjs/add/operator/map');
require('rxjs/add/operator/switchMap');
require('rxjs/add/operator/toPromise');
require('rxjs/add/operator/share');
var Observable_1 = require('rxjs/Observable');
var baseHttpService_1 = require('./http/baseHttpService');
var ServerService = (function (_super) {
    __extends(ServerService, _super);
    function ServerService(http) {
        var _this = this;
        _super.call(this, http);
        this.serverList = new Array();
        this.servers = new Observable_1.Observable(function (observer) { return _this.serversObserver = observer; }).share();
    }
    ServerService.prototype.loadStatistics = function () {
        var _this = this;
        var control = 'Server';
        var action = 'GetStatistics/';
        var url = this.serverName + control + '/' + action;
        this.http.get(url, { headers: this.headers })
            .map(function (response) { return response.json(); })
            .subscribe(function (data) {
            _this.serverList = data.Data;
            _this.serversObserver.next(_this.serverList);
        }, function (err) { return console.log('An error has occurred: ' + JSON.stringify(err)); });
    };
    ServerService = __decorate([
        core_1.Injectable(),
        __param(0, core_1.Inject(http_1.Http)), 
        __metadata('design:paramtypes', [Object])
    ], ServerService);
    return ServerService;
}(baseHttpService_1.BaseHttpService));
exports.ServerService = ServerService;
//# sourceMappingURL=serverService.js.map