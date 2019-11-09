import { Foto } from './foto';
import { Proprietario } from './proprietario';
import { Endereco } from './endereco';
import { EStatusObra } from '../enum/EStatusObra';
import { Responsavel } from './responsavel';
export class Obra {
    constructor(
        public nome?: string,
        public Imagem?: Foto,
        public statusObra?: EStatusObra,
        public endereco?: Endereco,
        public proprietario?: Proprietario,
        public Residente?: Responsavel,

        public Fiscal1?: Responsavel,
        public Fiscal2?: Responsavel,
        public Relatorio?: any,
        public dataInicio?: Date,
        public dataFinal?: Date,
    ) { }
}
