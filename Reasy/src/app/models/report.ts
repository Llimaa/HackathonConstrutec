import { Responsible } from './responsible';
import { Construction } from './construction';
import { Comments } from './comment';


export class Report {
    constructor(
        public Title?: string,
        public Image?: string,
        public Description?: string,
        public Responsible?: Responsible,
        public Construction?: Construction,
        public Comments?: Comments,
        public DateReport?: Date,
    ) { }
}