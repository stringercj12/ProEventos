import {Pipe, PipeTransform} from '@angular/core';
import {Evento} from "../eventos/eventos.component";

@Pipe({
  name: 'buscarEvento'
})
export class BuscarEventoPipe implements PipeTransform {

  transform(eventos: Evento[], value: string): Evento[] {
    if (!value) {
      return eventos;
    }

    return eventos.filter(evento => {
      if (evento.tema.toLowerCase().includes(value.toLowerCase())) {
        return evento;
      }

      return null;
    }).filter(item => item != null);
  }

}
