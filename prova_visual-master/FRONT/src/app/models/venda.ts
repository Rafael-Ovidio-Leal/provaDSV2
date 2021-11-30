import { Pagamento } from './pagamento';
import { ItemVenda } from './item-venda';


export interface Venda {

    vendaId?: number;
    cliente: string;
    pagamento?: Pagamento[];
    valor: number;
    criadoem?: string;
    itens?: ItemVenda[];

}