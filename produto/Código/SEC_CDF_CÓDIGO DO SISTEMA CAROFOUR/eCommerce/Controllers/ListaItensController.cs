using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;
using Negocio.DAO;

namespace eCommerce.Controllers
{
    public class ListaItensController : Controller
    {
        //
        // GET: /ListaItens/

        public ActionResult Index(int? CodCategoria)
        {
            IList<Negocio.Model.Produto> lstProdutosCategoria = new List<Negocio.Model.Produto>();
            CategoriaDAO lstCategorias = new CategoriaDAO();
            ProdutoDAO produto = new ProdutoDAO();                    
            //Fazer método de chamada ao banco de dados

            ViewBag.Categoria = lstCategorias.SelectAll();

            lstProdutosCategoria = produto.SelectByCategoria(CodCategoria);
                  
                    
            return View(lstProdutosCategoria);            
        }
        
        public ActionResult AddProdutoCarrinho(int produtoId)
        {            
            IList<Negocio.Model.Produto> produtos = new List<Negocio.Model.Produto>();
            Negocio.DAO.ProdutoDAO produtoDAO = new ProdutoDAO();

            if (Session["produtos"] != null)
            {
                Negocio.Model.Produto produto = new Negocio.Model.Produto();
                produto = produtoDAO.SelectById(produtoId);
                produto._Quantidade = 1;
                ((IList<Negocio.Model.Produto>)Session["produtos"]).Add(produtoDAO.SelectById(produtoId));                    
            }
            else
            {
                Negocio.Model.Produto produto = new Negocio.Model.Produto();
                produto = produtoDAO.SelectById(produtoId);
                produto._Quantidade = 1;
                produtos.Add(produto);
                    
                Session["produtos"] = produtos;
            }            

            return RedirectToAction("Index", "Carrinho");
        }

        [HttpPost]
        public ActionResult AddProdutoCarrinho(IList<int> produto)
        {
            if(produto != null)
            {
                IList<Negocio.Model.Produto> produtos = new List<Negocio.Model.Produto>();
                Negocio.DAO.ProdutoDAO produtoDAO = new ProdutoDAO();

                if (Session["produtos"] != null)
                {
                    foreach (int produtoId in produto)
                    {
                        Negocio.Model.Produto objProduto = new Negocio.Model.Produto();
                        objProduto = produtoDAO.SelectById(produtoId);
                        objProduto._Quantidade = 1;
                        ((IList<Negocio.Model.Produto>)Session["produtos"]).Add(objProduto); 
                    }                
                }
                else
                {
                    foreach (int produtoId in produto)
                    {
                        Negocio.Model.Produto objProduto = new Negocio.Model.Produto();
                        objProduto = produtoDAO.SelectById(produtoId);
                        objProduto._Quantidade = 1;

                        produtos.Add(objProduto); 
                    }

                    Session["produtos"] = produtos;
                }
            }

            return RedirectToAction("Index", "Carrinho");
        }
    }
}
