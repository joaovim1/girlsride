using GirlsRide.Web.Models;
using GirlsRide.Web.Percistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GirlsRide.Web.Controllers
{
    public class ClienteController : Controller
    {
        private GirlsRideContext _context;

        public ClienteController(GirlsRideContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Agendamento(int id)
        {
            var clienteAgendamento = _context.clienteAgendamentos
                .Where(v=> v.ClienteId == id)
                .Select(v => v.Agendamento)
                .ToList();

            ViewBag.clienteAgendamento = clienteAgendamento;

            var lista = _context.Agendamentos.ToList();

            ViewBag.agendamento = new SelectList(lista, "Id", "AgendamentoNo");

            var cliente = _context.Clientes.Find(id);

            return View(cliente);
        }
        [HttpPost]
        public IActionResult Adicionar(ClienteAgendamento clienteAgendamento)
        {
            _context.clienteAgendamentos.Add(clienteAgendamento);
            _context.SaveChanges();
            TempData["msgagf"] = "Ride Agendada!";
            return RedirectToAction("Agendamento", new {id = clienteAgendamento.ClienteId});
        }
        [HttpPost]
        public IActionResult Remover(int id)
        {
            var clienteRemover = _context.Clientes.Find(id);
            _context.Clientes.Remove(clienteRemover);
            _context.SaveChanges();

            TempData["msg"] = "Ride cancelada!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();

            TempData["msg"] = "Registro Atualizado!";

            return RedirectToAction("Index");

        }
 


        [HttpGet]
        public IActionResult Editar(int id)

        {
            var lista = _context.Carros.ToList();
            ViewBag.carrosList = new SelectList(lista, "Id", "ModeloCarro");

            var listaCartao = _context.Cartoes.ToList();
            ViewBag.cartoesList = new SelectList(listaCartao, "Id", "nrCartao");
            var cliente = _context.Clientes.Find(id);

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
       
                if (cliente.CartaoId != 0)
                {
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();

                    TempData["msg"] = "Ride iniciada com sucesso!";
                    return RedirectToAction("Index2");
                }
                else
                {
                    TempData["msge"] = "Você precisa selecionar um Cartão";
                     return RedirectToAction("CadastrarCartao");
                }
               
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var lista = _context.Carros.ToList();
            ViewBag.carrosList = new SelectList(lista, "Id", "ModeloCarro");

            var listaCartao = _context.Cartoes.ToList();
            ViewBag.cartoesList = new SelectList(listaCartao, "Id", "nrCartao");

            return View();

        }

        [HttpPost]
        public IActionResult CadastrarCartao(Cartao cartao)
        {
            _context.Cartoes.Add(cartao);
            _context.SaveChanges();

            TempData["msgCartao"] = "Cartão cadastrado com sucesso!";

            return RedirectToAction("CadastrarCartao");
        }

        [HttpGet]
        public IActionResult CadastrarCartao()
        {
            var cartao = _context.Cartoes.ToList();
            return View();

        }
        public IActionResult Index(string nome)
        {
            var lista = _context.Clientes.Where(c => c.Name.Contains(nome) || nome == null).Include(v => v.Carros).Include(p => p.Pagamentos)
                .ToList();

            return View(lista);
        }

        public IActionResult Index2(string nome)
        {
            var lista = _context.Clientes.Where(c => c.Name.Contains(nome) || nome == null).Include(v => v.Carros).Include(p => p.Pagamentos)
                .ToList();

            return View(lista);
        }

        public IActionResult IndexCartoes()
        {
            var lista = _context.Cartoes.ToList();

            return View(lista);
        }


        [HttpPost]
        public IActionResult RemoverCt(int id)
        {
            var RemoverCartao = _context.Cartoes.Find(id);
            _context.Cartoes.Remove(RemoverCartao);
            _context.SaveChanges();

            TempData["msgcr"] = "Cartão removido!";

            return RedirectToAction("IndexCartoes");
        }
    }
}
