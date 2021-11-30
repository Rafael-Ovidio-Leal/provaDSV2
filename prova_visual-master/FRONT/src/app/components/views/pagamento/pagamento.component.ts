import { VendaService } from 'src/app/services/venda.service';
import { Venda } from './../../../models/venda';
import { ItemVenda } from './../../../models/item-venda';
import { Pagamento } from './../../../models/pagamento';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ItemService } from 'src/app/services/item.service';
import { PagamentoService } from './../../../services/pagamento.service';

@Component({
  selector: 'app-pagamento',
  templateUrl: './pagamento.component.html',
  styleUrls: ['./pagamento.component.css']
})
export class PagamentoComponent implements OnInit {
    itens: ItemVenda[] = [];
    pagamentos: Pagamento[] = [];
    valorTotal!: number;
    disc!: number;
    total!: number;

    pagamento: Pagamento[] = [];
    nome!: string;

    constructor(
        private itemService: ItemService,
        private pagamentoService: PagamentoService,
        private vendaService: VendaService,
        private router: Router,
    ) {}

  private routeSub: Subscription = new Subscription();

  ngOnInit(): void {
    let carrinhoId = localStorage.getItem("carrinhoId")! || "";
    this.itemService.getByCartId(carrinhoId).subscribe((itens) => {
        this.itens = itens;
        this.valorTotal = this.itens.reduce((total, item) => {
            return total + item.preco * item.quantidade;
        }, 0);
    });

    this.pagamentoService.list().subscribe((pagamentos) => {
        this.pagamentos = pagamentos;
        console.log(this.pagamentos)
    });

  }

  finalizar(){
        if(this.pagamento[0].desconto != null || this.pagamento[0].juros != null){
            this.disc = this.pagamento[0].desconto != null ? this.pagamento[0].desconto : this.pagamento[0].juros;
        }else this.disc = 0


        this.total = this.valorTotal - this.disc
    let venda: Venda = {
        cliente: this.nome,
        pagamento: this.pagamento,
        itens: this.itens,
        valor: this.total,
    };

    console.log(venda);
    this.vendaService.create(venda).subscribe((venda) => {

        this.router.navigate(["venda/listar"]);
    });
  }
}
