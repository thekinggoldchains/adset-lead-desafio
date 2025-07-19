// EXEMPLO DE USO DO API SERVICE
// Este arquivo mostra como usar o ApiService em seus componentes

import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';

@Component({
  selector: 'app-exemplo',
  template: `<div>Exemplo de uso do ApiService</div>`
})
export class ExemploComponent implements OnInit {

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.exemploGetDados();
  }

  // EXEMPLO 1: Buscar dados (GET)
  exemploGetDados() {
    // Buscar todos os veículos
    this.apiService.get('veiculo').subscribe({
      next: (dados) => {
        console.log('Veículos recebidos:', dados);
      },
      error: (erro) => {
        console.error('Erro ao buscar veículos:', erro);
      }
    });

    // Buscar com filtros
    const filtros = {
      marca: 'Toyota',
      ano: 2023,
      cor: 'Azul'
    };
    
    this.apiService.get('veiculo', '', filtros).subscribe({
      next: (dados) => {
        console.log('Veículos filtrados:', dados);
      }
    });

    // Buscar um veículo específico
    this.apiService.get('veiculo', '123').subscribe({
      next: (veiculo) => {
        console.log('Veículo específico:', veiculo);
      }
    });
  }

  // EXEMPLO 2: Criar dados (POST)
  exemploSalvarDados() {
    const novoVeiculo = {
      marca: 'Honda',
      modelo: 'Civic',
      ano: 2024,
      cor: 'Branco'
    };

    this.apiService.post('veiculo', novoVeiculo).subscribe({
      next: (resultado) => {
        console.log('Veículo criado com sucesso:', resultado);
      },
      error: (erro) => {
        console.error('Erro ao criar veículo:', erro);
      }
    });
  }

  // EXEMPLO 3: Atualizar dados (PUT)
  exemploAtualizarDados() {
    const veiculoAtualizado = {
      id: 123,
      marca: 'Honda',
      modelo: 'Civic',
      ano: 2024,
      cor: 'Preto' // Mudando a cor
    };

    this.apiService.put('veiculo', veiculoAtualizado).subscribe({
      next: (resultado) => {
        console.log('Veículo atualizado:', resultado);
      }
    });
  }

  // EXEMPLO 4: Atualização parcial (PATCH)
  exemploAtualizacaoParcial() {
    const dadosParciais = {
      id: 123,
      cor: 'Verde' // Só mudando a cor
    };

    this.apiService.patch('veiculo', dadosParciais).subscribe({
      next: (resultado) => {
        console.log('Cor atualizada:', resultado);
      }
    });
  }

  // EXEMPLO 5: Deletar dados (DELETE)
  exemploExcluirDados() {
    const veiculo = { id: 123 };

    this.apiService.delete('veiculo', veiculo).subscribe({
      next: (resultado) => {
        console.log('Veículo excluído:', resultado);
      }
    });
  }

  // EXEMPLO 6: Upload de arquivo
  exemploUploadArquivo(event: any) {
    const arquivo = event.target.files[0];
    
    if (arquivo) {
      const dadosAdicionais = {
        veiculoId: 123,
        tipo: 'foto'
      };

      this.apiService.uploadFile('veiculo/upload', arquivo, dadosAdicionais).subscribe({
        next: (resultado) => {
          console.log('Arquivo enviado:', resultado);
        }
      });
    }
  }

  // EXEMPLO 7: Verificar loading
  verificarLoading() {
    console.log('API está carregando?', this.apiService.isLoading);
  }

  // EXEMPLO 8: Configurar nova URL base
  configurarNovaUrl() {
    this.apiService.setBaseUrl('https://nova-api.com/api');
  }
}

/* 
CONFIGURAÇÕES IMPORTANTES:

1. URL da API:
   - Desenvolvimento: https://localhost:7001/api
   - Produção: https://api.producao.com/api
   - Pode ser alterada no environment.ts

2. Autenticação:
   - O service busca automaticamente o token no localStorage
   - Chave: 'authToken'
   - Formato: Bearer token

3. Headers automáticos:
   - Content-Type: application/json
   - Authorization: Bearer {token}

4. Tratamento de erros:
   - Erros são logados no console
   - Mensagens de erro personalizadas por status HTTP
   - Retorna Observable com erro

5. Loading:
   - Controlado automaticamente
   - Pode ser desabilitado passando showLoading: false
   - Estado acessível via apiService.isLoading

ESTRUTURA DE ENDPOINTS ESPERADA:
- GET /api/veiculo - Listar todos
- GET /api/veiculo?marca=Honda - Listar com filtros  
- GET /api/veiculo/123 - Buscar por ID
- POST /api/veiculo - Criar novo
- PUT /api/veiculo - Atualizar completo
- PATCH /api/veiculo - Atualizar parcial
- DELETE /api/veiculo/123 - Excluir por ID
*/
