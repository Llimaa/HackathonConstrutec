import { Construction } from '../../models/construction';
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Api } from 'src/api/api';
import { Observable } from 'rxjs';

type EntityArrayResponseType = HttpResponse<Construction[]>;

@Injectable({
    providedIn: 'root'
})
export class DenunciaService {
    private resourceUrl = Api.API_URL + '/obras';

    constructor(private http: HttpClient) {
    }

    create(obra: Construction): Observable<Construction> {
        return this.http.post(this.resourceUrl, obra);
    }

    update(obra: Construction): Observable<Construction> {
        return this.http.put(this.resourceUrl, obra);
    }

    find(id: number): Observable<Construction> {
        return this.http.get(`${this.resourceUrl}/${id}`);
    }

    query(req?: any): Observable<any> {
        return this.http.get(this.resourceUrl);
    }

    delete(id: number): Observable<any> {
        return this.http.delete(`${this.resourceUrl}/${id}`, { observe: 'response', responseType: 'text' });
    }
}
