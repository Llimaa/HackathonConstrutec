import { Obra } from './obra';
import { Foto } from './foto';
export class Responsavel {
    constructor(
        public nome?: string,
        public crea?: string,
        public email?: string,
        public telefone?: string,
        public obras?: Obra[],

    ) { }
}
