using GirlsRide.Web.Models;
using GirlsRide.Web.Percistencia;
using Microsoft.AspNetCore.Mvc;

namespace GirlsRide.Web.Controllers
{
    public class AvaliacaoController : Controller
    {
        private GirlsRideContext _context;

        public AvaliacaoController(GirlsRideContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Cadastrar(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            _context.SaveChanges();

            TempData["msga"] = "Avaliação feita com sucesso!";

            return RedirectToAction("Cadastrar");
        }
        
        [HttpGet]
        public IActionResult Cadastrar()
        {
          
            return View();
        }
        public IActionResult Index()
        {
            var lista = _context.Avaliacoes.ToList();
            return View(lista);
        }
    }
}
