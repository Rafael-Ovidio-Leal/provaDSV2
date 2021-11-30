using System;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/pagamento")]
    public class PagamentoController : ControllerBase
    {
        private readonly DataContext _context;
        public PagamentoController(DataContext context)
        {
            _context = context;
        }

        //GET: api/pagamento/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Pagamentos.ToList());

    }
}