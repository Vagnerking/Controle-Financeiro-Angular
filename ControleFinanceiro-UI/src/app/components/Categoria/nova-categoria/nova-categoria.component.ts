import { CategoriasService } from 'src/app/services/categorias.service';
import { Component, OnInit } from '@angular/core';
import { Tipo } from 'src/app/models/Tipo';
import { TiposService } from 'src/app/services/tipos.service';
import { FormGroup, FormControl } from '@angular/forms';
import { ThisReceiver } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nova-categoria',
  templateUrl: './nova-categoria.component.html',
  styleUrls: ['../listagem-categorias/listagem-categorias.component.css']
})
export class NovaCategoriaComponent implements OnInit {

  formulario: any;
  tipos: Tipo[];

  constructor(private tipoService: TiposService, private categoriaService: CategoriasService,
    private route: Router) { }

  ngOnInit(): void {

    this.tipoService.PegarTodos().subscribe(resultado => {
      this.tipos = resultado;
    });

    this.formulario = new FormGroup({
      nome : new FormControl(null),
      icone : new FormControl(null),
      tipoId : new FormControl(null)
    });

  }

  getPropriedade(){
    return this.formulario.controls;
  }

  EnviarFormulario(): void{
    const categoria = this.formulario.value;

    this.categoriaService.NovaCategoria(categoria).subscribe(resultado => {
    this.route.navigate(['categorias/listagemcategorias']);
    });

  }

}
