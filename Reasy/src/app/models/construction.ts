import { Owner } from './owner';
import { Address } from './address';
import { Foto } from './foto';
import { EStatusConstruction } from '../enum/EStatusConstruction';
import { Responsible } from './responsible';
export class Construction {
    constructor(
        public Name?: string,
        public Image?: string,
        public sStatusConstruction?: EStatusConstruction,
        public responsibles?: Responsible[],
        public address?: Address,
        public owner?: Owner,
        public StartDate?: Date,
        public FinalDate?: Date,
    ) { }
}
