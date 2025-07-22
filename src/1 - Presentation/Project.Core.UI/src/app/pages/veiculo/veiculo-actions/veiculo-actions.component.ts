import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';

interface Veiculo {
  id: number;
  marca: string;
  modelo: string;
  ano: number;
  placa: string;
  km: number;
  cor: string;
  preco: number;
  fotos: string[];
  opcionais: string[];
}

@Component({
  selector: 'app-veiculo-actions',
  templateUrl: './veiculo-actions.component.html',
  styleUrls: ['./veiculo-actions.component.scss']
})
export class VeiculoActionsComponent implements OnInit {
  veiculos = [
    {
      placa: 'AAA-0102',
      km: 25000,
      cor: 'Branco',
      preco: 103900,
      imagem: 'assets/golf.jpg',
      status: {
        iCarros: { diamanteFeirao: [10, 8], diamante: [30, 25], platinum: [40, 10] },
        webMotors: { basico: [30, 25] }
      }
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

  cadastrarVeiculo(): void {
    console.log('Cadastrar novo veículo');
  }
}
