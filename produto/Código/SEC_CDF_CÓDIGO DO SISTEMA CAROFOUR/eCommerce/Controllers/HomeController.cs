using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio.DAO;
using Negocio.Model;

namespace eCommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.Message = "Bem vindo!";

            CategoriaDAO categoria = new CategoriaDAO();
            IList<Categoria> categorias = new List<Categoria>();
            categorias = categoria.SelectAll();            

            return View(categorias);
        }        
    }
}
