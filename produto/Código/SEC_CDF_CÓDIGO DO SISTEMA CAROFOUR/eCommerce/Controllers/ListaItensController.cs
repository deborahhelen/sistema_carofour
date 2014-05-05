using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;

namespace eCommerce.Controllers
{
    public class ListaItensController : Controller
    {
        //
        // GET: /ListaItens/

        public ActionResult Index(int? CodCategoria)
        {
            List<Produto> lstProdutosCategoria = new List<Produto>();
            //Fazer método de chamada ao banco de dados
           
            switch (CodCategoria)
            {
                case 1://Hortifrutigranjeiros
                    lstProdutosCategoria.Add(new Produto(1,"Maça","",50));
                    lstProdutosCategoria.Add(new Produto(1, "Banana", "", 50));
                    lstProdutosCategoria.Add(new Produto(1, "Alface", "", 50));
                    lstProdutosCategoria.Add(new Produto(1, "Tomate", "Tomate", 50));
                    break;
                case 2://Padaria
                    lstProdutosCategoria.Add(new Produto(1, "Pão de forma", "", 50));
                   lstProdutosCategoria.Add(new Produto(2,"Bolo","",50));
                    lstProdutosCategoria.Add(new Produto(1, "Pão francês", "", 50));
                   
                    break;
                case 3:         //laticinios          
                    lstProdutosCategoria.Add(new Produto(1, "Leite desnatado", "", 50));
                    lstProdutosCategoria.Add(new Produto(2, "Queijo minas", "", 50));
                    lstProdutosCategoria.Add(new Produto(1, "Queijo prato", "", 50));
                    break;
                case 4://Carnes
                   lstProdutosCategoria.Add(new Produto(1,"Frango congelado","",50));
                    lstProdutosCategoria.Add(new Produto(1, "Peixe", "", 50));
                    lstProdutosCategoria.Add(new Produto(100, "Bacon fatiado", "", 50));                    
                    break;
                default://Tratar isso
                    lstProdutosCategoria.Add(new Produto(1,"Maça","",50));
                    lstProdutosCategoria.Add(new Produto(1, "Banana", "", 50));
                    lstProdutosCategoria.Add(new Produto(1, "Alface", "", 50));
                    lstProdutosCategoria.Add(new Produto(1, "Tomate", "Tomate", 50));
                    break;
            }

            //buscar as categorias do banco e preencher a tabela de produtos
            return View(lstProdutosCategoria);
        }
        public ActionResult AddProdutoCarrinho(int CodProduto)
        {
            return View();
        }
    }
}
