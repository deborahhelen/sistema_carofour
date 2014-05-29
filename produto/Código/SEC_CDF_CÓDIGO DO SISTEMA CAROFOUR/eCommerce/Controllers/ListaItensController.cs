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

        //Buscar os produtos de uma categoria passada por parametro
        public ActionResult Index(int? CodCategoria)
        {
            IList<Negocio.Model.Produto> lstProdutosCategoria = new List<Negocio.Model.Produto>();
            CategoriaDAO lstCategorias = new CategoriaDAO();
            ProdutoDAO produto = new ProdutoDAO();     
            
  
            ViewBag.Categoria = lstCategorias.SelectAll();

            lstProdutosCategoria = produto.SelectByCategoria(CodCategoria);
                  
                    
            return View(lstProdutosCategoria);            
        }
        
        // Adiciona apenas um produto no carrinho ( Botão Comprar )
        public ActionResult AddProdutoCarrinho(int produtoId)
        {            
            IList<Negocio.Model.Produto> produtos = new List<Negocio.Model.Produto>();
            Negocio.DAO.ProdutoDAO produtoDAO = new ProdutoDAO();

            // Verifica se a sessão de produtos já esta aberta
            // Sim -> ele apenas adiciona o produto no carrinho
            // Não -> ele cria a sessão de produtos e adiciona o produto no carrinho
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

        // Pega o produto selecionado e coloca no carrinho
        [HttpPost]

        //Adiciona vários produtos ao carrinho de uma só vez
        public ActionResult AddProdutoCarrinho(IList<int> produto)
        {
            // Verifica se a lista tem algum produto
            if(produto != null)
            {
                IList<Negocio.Model.Produto> produtos = new List<Negocio.Model.Produto>();
                Negocio.DAO.ProdutoDAO produtoDAO = new ProdutoDAO();

                // Mesmo passo do anterior
                if (Session["produtos"] != null)
                {
                    // Percorre a lista para adicionar os produtos
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
