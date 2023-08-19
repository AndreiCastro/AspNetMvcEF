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

        public IActionResult Update(int id)
        {
            var contato = _repository.GetContato(id);
            return View(contato);
        }

        public IActionResult DeleteConfirm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(ContatoModel contato) 
        {
            _repository.Add(contato);
            if(_repository.SaveChanges())
                return RedirectToAction("Index");

            return View("Erro");
        }

        [HttpPost]
        public IActionResult Put(ContatoModel contato) 
        {
            var contatoDb = _repository.GetContato(contato.Id);
            if(contatoDb != null)            
                _repository.Update(contato);
                    
            if(_repository.SaveChanges())
                return RedirectToAction("Index");
            
            return View("Erro");
            
        }
    }
}
