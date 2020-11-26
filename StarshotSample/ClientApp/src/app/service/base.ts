import { HttpHeaders } from "@angular/common/http";

export class Base {

    constructor(){

    }

    private _headers: HttpHeaders = new HttpHeaders();
    get headers(): HttpHeaders {
        
        var token = localStorage.getItem("Authorization");
        this._headers = this._headers.set("Authorization", token);
        return this._headers;
    }
    set headers(value: HttpHeaders) {
        this._headers = value;
    }
}
