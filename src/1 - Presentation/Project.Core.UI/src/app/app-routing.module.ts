import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/veiculo', pathMatch: 'full' },
  {
    path: "veiculo",
    loadChildren: () => import("./pages/veiculo/veiculo.module").then((m) => m.VeiculoModule),
  },
  { path: '**', redirectTo: '/veiculo' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
