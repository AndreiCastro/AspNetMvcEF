using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
    }
}
