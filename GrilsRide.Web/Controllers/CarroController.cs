using GirlsRide.Web.Models;
using GirlsRide.Web.Percistencia;
using Microsoft.AspNetCore.Mvc;

namespace GrilsRide.Web.Controllers
{
    public class CarroController : Controller
    {
        private GirlsRideContext _context;

        public CarroController(GirlsRideContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult RemoverCarro(int id)
        {
            var Remover = _context.Carros.Find(id);
            _context.Carros.Remove(Remover);
            _context.SaveChanges();

            TempData["msgc"] = "Carro removido!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Carro carro)
        {
            _context.Carros.Update(carro);
            _context.SaveChanges();

            TempData["msgc"] = "carro Atualizado!";

            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult Editar(int id)
        {
            var carro = _context.Carros.Find(id);

            return View(carro);
        }

        [HttpPost]
        public IActionResult Cadastrar(Carro carros)
        {
            _context.Carros.Add(carros);
            _context.SaveChanges();

            TempData["msgc"] = "Carro cadastrado com sucesso!";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var lista = _context.Carros.ToList();

            return View();

        }


        public IActionResult Index(string placa)
        {
            var lista = _context.Carros.Where(c => c.Placa.Contains(placa) || placa == null).ToList();

            return View(lista);
        }

        public IActionResult Index2(string placa )
        {
            var lista = _context.Carros.Where(c => c.Placa.Contains(placa) || placa == null).ToList();

            return View(lista);
        }

    }


}
