using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Livros" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Harry Potter", Preco = 90, Quantidade = 3, CategoriaId = 1, Genero = "Aventura", Paginas = 350},
                    new Produto { ProdutoId = 2, Nome = "Capitões de areia", Preco = 50, Quantidade = 4, CategoriaId = 1, Genero = "Aventura", Paginas = 250},
                    new Produto { ProdutoId = 3, Nome = "Biblia", Preco = 25, Quantidade = 8, CategoriaId = 1, Genero = "Religioso", Paginas = 1000},
                }
            );
            _context.Pagamentos.AddRange(new Pagamento[]
                {
                    new Pagamento { PagamentoId = 1, Forma = "Boleto", Desconto = 0, Juros = 0},
                    new Pagamento { PagamentoId = 2, Forma = "Pix", Desconto = 10, Juros = 0},
                    new Pagamento { PagamentoId = 3, Forma = "PayPal", Desconto = 0, Juros = 5},
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}