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
        #region Index
        public IActionResult Index()
        {
            var contatos = _repository.GetAllContatos();
            return View(contatos);
        }
        #endregion Index

        #region Post
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(ContatoModel contato)
        {
            _repository.Add(contato);
            if (_repository.SaveChanges())
                return RedirectToAction("Index");

            return BadRequest("Erro");
        }
        #endregion Post

        #region Update
        public IActionResult Update(int id)
        {
            var contato = _repository.GetContato(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Put(ContatoModel contato)
        {
            var contatoDb = _repository.GetContato(contato.Id);
            if (contatoDb != null)
                _repository.Update(contato);

            if (_repository.SaveChanges())
                return RedirectToAction("Index");

            return BadRequest("Erro");

        }
        #endregion Update

        #region Delete
        public IActionResult DeleteConfirm(int id)
        {
            var contato = _repository.GetContato(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {
            var contato = _repository.GetContato(id);
            if (contato != null)
                _repository.Delete(contato);

            if(_repository.SaveChanges())
                return RedirectToAction("Index");

            return BadRequest("Erro");
        }
        #endregion Delete


    }
}
