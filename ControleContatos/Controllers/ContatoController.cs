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
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(contato);
                    if (_repository.SaveChanges())
                    {
                        TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                        return RedirectToAction("Index");
                    }
                }
                return View("Add", contato);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar contado!";
                return RedirectToAction("Index");
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    var contatoDb = _repository.GetContato(contato.Id);
                    if (contatoDb != null)
                        _repository.Update(contato);

                    if (_repository.SaveChanges())
                    {                        
                        TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                        return RedirectToAction("Index");
                    }
                }
                return View("Update", contato);
            }
            catch (System.Exception)
            {                
                TempData["MensagemErro"] = "Erro ao alterar contato!";
                return RedirectToAction("Index");
            }
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
            try
            {
                var contato = _repository.GetContato(id);
                if (contato != null)
                    _repository.Delete(contato);

                if (_repository.SaveChanges())
                {
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao excluído contato!";
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao excluído contato!";
                return RedirectToAction("Index");
            }
        }
        #endregion Delete


    }
}
