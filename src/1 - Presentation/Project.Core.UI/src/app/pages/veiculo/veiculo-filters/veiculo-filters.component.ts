import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

interface VeiculoFilters {
  placa: string;
  marca: string;
  modelo: string;
  anoMin: string;
  anoMax: string;
  preco: string;
  fotos: string;
  opcionais: string;
  cor: string;
}

@Component({
  selector: 'app-veiculo-filters',
  templateUrl: './veiculo-filters.component.html',
  styleUrls: ['./veiculo-filters.component.scss'],

})
export class VeiculoFiltersComponent implements OnInit {

  @Output() filtrosAplicados = new EventEmitter<VeiculoFilters>();
  @Output() filtrosLimpos = new EventEmitter<void>();

  filters: VeiculoFilters = {
    placa: '',
    marca: '',
    modelo: '',
    anoMin: '',
    anoMax: '',
    preco: '',
    fotos: '',
    opcionais: '',
    cor: ''
  };

  constructor() { }



  ngOnInit(): void {
  }

  buscar(): void {
    console.log('Filtros aplicados:', this.filters);
    this.filtrosAplicados.emit({ ...this.filters });
  }

  limparFiltros(): void {
    this.filters = {
      placa: '',
      marca: '',
      modelo: '',
      anoMin: '',
      anoMax: '',
      preco: '',
      fotos: '',
      opcionais: '',
      cor: ''
    };
    console.log('Filtros limpos');
    this.filtrosLimpos.emit();
  }

  // Método para aplicar filtros automaticamente quando algum campo for alterado
  onFilterChange(): void {
    // Opcional: aplicar filtros automaticamente
    // this.buscar();
  }
}
