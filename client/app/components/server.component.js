"use strict";
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
var router_deprecated_1 = require('@angular/router-deprecated');
var serverService_1 = require('../services/serverService');
var ServerComponent = (function () {
    function ServerComponent(http, serverService, _router, elementRef) {
        this.http = http;
        this.serverService = serverService;
        this._router = _router;
        this.elementRef = elementRef;
        this.selectedInterval = "5";
    }
    ServerComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.serverStatsList = this.serverService.servers;
        this.worker = setInterval(function () { _this.processStats(); }, +this.selectedInterval * 1000);
    };
    ServerComponent.prototype.onSelectChange = function (interval) {
        this.selectedInterval = interval;
    };
    ServerComponent.prototype.processStats = function () {
        // this.serverStatsList.subscribe(l => console.log(l));
        this.serverService.loadStatistics();
    };
    ServerComponent = __decorate([
        core_1.Component({
            templateUrl: 'app/templates/server-template.html',
            styles: ["td.content { padding: 0 10px 17px 10px; vertical-align: bottom; }"],
            providers: [serverService_1.ServerService]
        }),
        __param(0, core_1.Inject(http_1.Http)), 
        __metadata('design:paramtypes', [http_1.Http, serverService_1.ServerService, router_deprecated_1.Router, core_1.ElementRef])
    ], ServerComponent);
    return ServerComponent;
}());
exports.ServerComponent = ServerComponent;
//# sourceMappingURL=server.component.js.map