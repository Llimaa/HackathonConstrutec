export class Foto {
    constructor(
        public data?: any,
        public fotoContentType?: string,
        public fotoTag?: any,
        public nativeURL?: string // caminho para efetuar o crop.
    ) { }
}
