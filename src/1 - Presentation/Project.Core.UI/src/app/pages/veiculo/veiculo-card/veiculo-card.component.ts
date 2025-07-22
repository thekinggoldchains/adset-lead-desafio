import { Component, Input, Output, EventEmitter } from '@angular/core';

export interface Veiculo {
  imagemUrl: string;
  marca: string;
  modelo: string;
  ano: number;
  placa: string;
  km: number;
  cor: string;
  preco: number;
  opcionais?: string[];
}

@Component({
  selector: 'app-veiculo-card',
  templateUrl: './veiculo-card.component.html',
  styleUrls: ['./veiculo-card.component.scss']
})
export class VeiculoCardComponent {
  @Input() veiculo!: Veiculo;
  @Output() editar = new EventEmitter<Veiculo>();
  @Output() remover = new EventEmitter<Veiculo>();

  editarVeiculo(v: Veiculo) {
    this.editar.emit(v);
  }

  removerVeiculo(v: Veiculo) {
    this.remover.emit(v);
  }
}
