import { Component } from '@angular/core';
import { Veiculo } from './veiculo-card/veiculo-card.component';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-veiculo',
  templateUrl: './veiculo.component.html',
  styleUrls: ['./veiculo.component.scss'],
    animations: [
    trigger('filtroAnim', [
      state('void', style({ height: '0', opacity: 0, overflow: 'hidden' })),
      state('*', style({ height: '*', opacity: 1, overflow: 'visible' })),
      transition('void <=> *', [animate('300ms cubic-bezier(.4,0,.2,1)')])
    ])
  ]
})

export class VeiculoComponent {
  veiculos: Veiculo[] = [
    {
      imagemUrl: 'assets/golf.jpg',
      marca: 'Volkswagen',
      modelo: 'Golf',
      ano: 2022,
      placa: 'AAA-0102',
      km: 25000,
      cor: 'Branco',
      preco: 103900,
      opcionais: ['Ar condicionado', 'Airbag', 'ABS']
    },
    {
      imagemUrl: 'assets/golf.jpg',
      marca: 'Fiat',
      modelo: 'Argo',
      ano: 2021,
      placa: 'BBB-1234',
      km: 18000,
      cor: 'Preto',
      preco: 79900,
      opcionais: ['Direção elétrica', 'Multimídia']
    },
    {
      imagemUrl: 'assets/golf.jpg',
      marca: 'Chevrolet',
      modelo: 'Onix',
      ano: 2023,
      placa: 'CCC-5678',
      km: 12000,
      cor: 'Prata',
      preco: 89900,
      opcionais: ['Sensor de estacionamento', 'Câmera de ré']
    }
  ];
  filtrosAbertos = true;
  toggleFiltro() { this.filtrosAbertos = !this.filtrosAbertos; }
  orderBy: string = 'marca';
  pageSize: number = 10;
  pageSizes: number[] = [5, 10, 20, 50];
  pageIndex: number = 0;

  get pagedVeiculos(): Veiculo[] {
    const sorted = [...this.veiculos].sort((a, b) => {
      const aValue = (a as any)[this.orderBy];
      const bValue = (b as any)[this.orderBy];
      if (typeof aValue === 'string') {
        return aValue.localeCompare(bValue);
      }
      return aValue - bValue;
    });
    const start = this.pageIndex * this.pageSize;
    return sorted.slice(start, start + this.pageSize);
  }

  onPageChange(event: any) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
  }

  onEditar(veiculo: Veiculo) {
    // lógica para editar veículo
    console.log('Editar', veiculo);
  }

  onRemover(veiculo: Veiculo) {
    // lógica para remover veículo
    console.log('Remover', veiculo);
  }

  
}
