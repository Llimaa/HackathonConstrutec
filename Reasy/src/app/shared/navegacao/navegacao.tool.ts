import { Router, NavigationExtras, ActivatedRoute } from '@angular/router';

export abstract class NavegacaoTool {

  protected parametros: any;

  constructor(
    protected route: ActivatedRoute,
    protected router: Router,
  ) {
    this.parametros = {};
  }

  protected async irPara(rota: string[], parametros?: any, rotaAnterior?: string) {
    if (rotaAnterior) {
      this.createEventBackButton(rotaAnterior);
    }

    if (parametros !== undefined) {
      const navigationExtras: NavigationExtras = {
        state: {
          parametros: parametros,
        }
      };
      this.router.navigate(rota, navigationExtras);
    } else {
      this.router.navigate(rota);
    }
  }

  protected buscarParametros() {
    return this.router.getCurrentNavigation().extras.state.parametros;
  }

  protected async createEventBackButton(path) {
  }
}
