import { Address } from './address';

export class Owner { //proprietario
    constructor(
        public Name?: string,
        public Phone?: string,
        public Email?: string,
        public Address?: Address,
    ) { }
}
