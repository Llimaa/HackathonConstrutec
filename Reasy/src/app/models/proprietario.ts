
import { Endereco } from './endereco';
import { EStatusObra } from '../enum/EStatusObra';
export class Proprietario {
    constructor(
        public nome?: string,
        public telefone?: string,
        public email?: string,
        public endereco?: Endereco,
    ) { }
}
