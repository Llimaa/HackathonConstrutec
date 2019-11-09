import { Report } from './report';
import { Responsible } from './responsible';

export class Comments {
    constructor(
        public Report?: Report,
        public Responsible?: Responsible,
        public Title?: string,
        public Description?: string,
    ) { }
}