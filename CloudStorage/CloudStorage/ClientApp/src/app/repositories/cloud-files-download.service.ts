import { HttpClient, HttpEvent, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({providedIn: 'root'})
export class DownloadService 
{
    constructor(private _httpClient: HttpClient) {}

    public DownloadFile(guid: string): Observable<HttpEvent<Blob>> 
    {
    return this._httpClient.request(new HttpRequest(        // TODO: implement UrlService
        'GET',
        `https://localhost:7060/api/cloudfiles/download?fileId=${guid}`,
        null,
        {
            reportProgress: true,
            responseType: 'blob'
        }));
    }
}

export interface ProgressStatus 
{
    status: ProgressStatusEnum;
    percentage?: number;
}
    
export enum ProgressStatusEnum 
{
    START, COMPLETE, IN_PROGRESS, ERROR
}