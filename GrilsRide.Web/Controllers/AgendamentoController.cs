using GirlsRide.Web.Models;
using GirlsRide.Web.Percistencia;
using Microsoft.AspNetCore.Mvc;

namespace GirlsRide.Web.Controllers
{
    public class AgendamentoController : Controller
    {
        private GirlsRideContext _context;

        public AgendamentoController(GirlsRideContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.lista = _context.Agendamentos.ToList();
            return View();
        }

        [HttpPost]

        public IActionResult Cadastrar(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();

            TempData["msgag"] = "Agendamento Cadastrado!";
            return RedirectToAction("Index");
        }
    }
}
