import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormControl} from "@angular/forms";

export interface Evento {
  eventoId: number;
  tema: string;
  local: string;
  lote: string;
  imagemUrl: string;
  quantidadeDePessoas: number;
  dataDoEvento: string;
}

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventos: Evento[] = [];
  searchFormControl: FormControl = new FormControl('');

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }


  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe({
      next: (eventos: any) => {
        this.eventos = eventos;
      }
    });
  }

}
