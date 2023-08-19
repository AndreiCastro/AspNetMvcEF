using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _repository;
        public ContatoController(IContatoRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var contatos = _repository.GetAllContatos();
            return View(contatos);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult DeleteConfirm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ContatoModel contato) 
        {
            _repository.Add(contato);
            if(_repository.SaveChanges())
                return RedirectToAction("Index");

            return View("Erro");
        }
    }
}
