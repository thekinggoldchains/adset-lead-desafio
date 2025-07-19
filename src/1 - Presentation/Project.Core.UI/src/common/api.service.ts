import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl: string;
  private loading: boolean = false;

  constructor(private http: HttpClient) {
    this.baseUrl = environment.apiUrl || 'https://localhost:7001/api';
  }

  /**
   * Método GET para buscar dados da API
   * @param resource - O recurso/endpoint da API
   * @param route - Rota adicional (opcional)
   * @param filters - Filtros para a consulta (opcional)
   * @param showLoading - Se deve mostrar loading (padrão: true)
   */
  get(resource: string, route?: string, filters?: any, showLoading: boolean = true): Observable<any> {
    if (showLoading) {
      this.setLoading(true);
    }

    let url = `${this.baseUrl}/${resource}`;
    if (route) {
      url += `/${route}`;
    }

    let params = new HttpParams();
    if (filters) {
      Object.keys(filters).forEach(key => {
        if (filters[key] !== null && filters[key] !== undefined && filters[key] !== '') {
          params = params.set(key, filters[key].toString());
        }
      });
    }

    const headers = this.getHeaders();

    return this.http.get(url, { headers, params }).pipe(
      catchError(this.handleError),
      finalize(() => {
        if (showLoading) {
          this.setLoading(false);
        }
      })
    );
  }

  /**
   * Método POST para criar novos dados
   * @param resource - O recurso/endpoint da API
   * @param model - Os dados a serem enviados
   * @param showLoading - Se deve mostrar loading (padrão: true)
   */
  post(resource: string, model: any, showLoading: boolean = true): Observable<any> {
    if (showLoading) {
      this.setLoading(true);
    }

    const url = `${this.baseUrl}/${resource}`;
    const headers = this.getHeaders();

    return this.http.post(url, model, { headers }).pipe(
      catchError(this.handleError),
      finalize(() => {
        if (showLoading) {
          this.setLoading(false);
        }
      })
    );
  }

  /**
   * Método PUT para atualizar dados existentes
   * @param resource - O recurso/endpoint da API
   * @param model - Os dados a serem atualizados
   * @param showLoading - Se deve mostrar loading (padrão: true)
   */
  put(resource: string, model: any, showLoading: boolean = true): Observable<any> {
    if (showLoading) {
      this.setLoading(true);
    }

    const url = `${this.baseUrl}/${resource}`;
    const headers = this.getHeaders();

    return this.http.put(url, model, { headers }).pipe(
      catchError(this.handleError),
      finalize(() => {
        if (showLoading) {
          this.setLoading(false);
        }
      })
    );
  }

  /**
   * Método DELETE para remover dados
   * @param resource - O recurso/endpoint da API
   * @param model - Os dados com identificador para remoção
   * @param showLoading - Se deve mostrar loading (padrão: true)
   */
  delete(resource: string, model: any, showLoading: boolean = true): Observable<any> {
    if (showLoading) {
      this.setLoading(true);
    }

    let url = `${this.baseUrl}/${resource}`;
    
    // Se o model tem um ID, adiciona à URL
    if (model && (model.id || model.Id)) {
      url += `/${model.id || model.Id}`;
    }

    const headers = this.getHeaders();

    return this.http.delete(url, { headers }).pipe(
      catchError(this.handleError),
      finalize(() => {
        if (showLoading) {
          this.setLoading(false);
        }
      })
    );
  }

  /**
   * Método PATCH para atualizações parciais
   * @param resource - O recurso/endpoint da API
   * @param model - Os dados para atualização parcial
   * @param showLoading - Se deve mostrar loading (padrão: true)
   */
  patch(resource: string, model: any, showLoading: boolean = true): Observable<any> {
    if (showLoading) {
      this.setLoading(true);
    }

    const url = `${this.baseUrl}/${resource}`;
    const headers = this.getHeaders();

    return this.http.patch(url, model, { headers }).pipe(
      catchError(this.handleError),
      finalize(() => {
        if (showLoading) {
          this.setLoading(false);
        }
      })
    );
  }

  /**
   * Configura os headers padrão para as requisições
   */
  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json'
    });
  }

  /**
   * Tratamento de erros
   */
  private handleError = (error: any): Observable<never> => {
    console.error('Erro na API:', error);
    
    let errorMessage = 'Erro desconhecido';
    
    if (error.error instanceof ErrorEvent) {
      // Erro do lado do cliente
      errorMessage = `Erro: ${error.error.message}`;
    } else {
      // Erro do lado do servidor
      switch (error.status) {
        case 400:
          errorMessage = 'Requisição inválida';
          break;
        case 401:
          errorMessage = 'Não autorizado';
          break;
        case 403:
          errorMessage = 'Acesso negado';
          break;
        case 404:
          errorMessage = 'Recurso não encontrado';
          break;
        case 500:
          errorMessage = 'Erro interno do servidor';
          break;
        default:
          errorMessage = `Erro: ${error.status} - ${error.message}`;
      }
    }

    return throwError(errorMessage);
  };

  /**
   * Controla o estado de loading
   */
  private setLoading(loading: boolean): void {
    this.loading = loading;
    // Aqui você pode implementar um serviço de loading global
    // Por exemplo: this.loadingService.setLoading(loading);
  }

  /**
   * Retorna o estado atual do loading
   */
  get isLoading(): boolean {
    return this.loading;
  }

  /**
   * Define uma nova URL base para a API
   */
  setBaseUrl(url: string): void {
    this.baseUrl = url;
  }

  /**
   * Retorna a URL base atual
   */
  getBaseUrl(): string {
    return this.baseUrl;
  }
}
