import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// Angular Material modules
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatTooltipModule } from '@angular/material/tooltip';

// Componentes do módulo
import { VeiculoComponent } from './veiculo.component';
import { VeiculoActionsComponent } from './veiculo-actions/veiculo-actions.component';
import { VeiculoRoutingModule } from './veiculo-routing.module';
import { VeiculoFiltersComponent } from './veiculo-filters/veiculo-filters.component';
import { VeiculoCardComponent } from './veiculo-card/veiculo-card.component';

@NgModule({
  declarations: [
    VeiculoComponent,
    VeiculoActionsComponent,
    VeiculoFiltersComponent,
    VeiculoCardComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    VeiculoRoutingModule,
    // Angular Material modules
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatPaginatorModule,
    MatSelectModule,
    MatTooltipModule
  ]
})
export class VeiculoModule { }
