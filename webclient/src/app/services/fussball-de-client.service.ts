import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class FussballDeClientService {
  constructor(private _httpClient: HttpClient) {}

  public getTeamOverviewPage(urlToPage: string): Observable<HttpResponse<any>> {
    return this._httpClient.get<any>(urlToPage, { observe: 'response' });
  }
}
