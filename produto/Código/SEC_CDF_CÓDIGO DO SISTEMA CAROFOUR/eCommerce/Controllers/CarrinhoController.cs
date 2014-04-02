using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        //
        // GET: /Carrinho/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FecharCompra()
        {
            return View();
        }

        public ActionResult DadosPedido()
        {
            return View();
        }

    }
}
