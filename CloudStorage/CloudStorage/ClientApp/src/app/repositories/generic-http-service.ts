import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({providedIn: 'root'})
export class GenericHttpService
{
    constructor(private _http: HttpClient)
    {
        
    }

    public Get<TResponse>(): Observable<TResponse>
	{
		return this._http.get<TResponse>("https://localhost:7060/api/CloudFiles");
	}

    public Post<TRequest, TResponse>(request: TRequest): Observable<TResponse>
    {
        return this._http.post<TResponse>("https://localhost:7060/api/CloudFiles", request);
    }
}