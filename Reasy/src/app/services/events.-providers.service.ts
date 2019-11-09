import { EventEmitter } from '@angular/core';

export class EventsService {

    private static emitirEvento: {
        [nomeEvento: string]: EventEmitter<any>
    } = {}

    static get(nomeEvento: string): EventEmitter<any> {
        if (!this.emitirEvento[nomeEvento])
            this.emitirEvento[nomeEvento] = new EventEmitter<any>();
        return this.emitirEvento[nomeEvento];
    }
}