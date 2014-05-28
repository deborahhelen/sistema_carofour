using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: /Carrinho/

        public ActionResult Index()
        {
            IList<Negocio.Model.Produto> produtos = new List<Negocio.Model.Produto>();

            if (Session["produtos"] != null)
            {
                produtos = ((IList<Negocio.Model.Produto>)Session["produtos"]).ToList();               
            }
            else
            {
                produtos = null;
            }

            ViewBag.SubTotal = CalculaSubTotal((IList<Negocio.Model.Produto>)Session["produtos"]).ToString("C");

            return View(produtos);
        }

        // Atualizar a quantidade do produto
        public ActionResult AtualizarQuantidade(int produtoId, string _Quantidade)
        {
            for (int i = 0; i < ((IList<Negocio.Model.Produto>)Session["produtos"]).ToList().Count; i++)
            {
                if (((IList<Negocio.Model.Produto>)Session["produtos"]).ToList()[i]._ProdutoId == produtoId)
                {
                    ((IList<Negocio.Model.Produto>)Session["produtos"]).ElementAt(i)._Quantidade = Convert.ToInt32(_Quantidade);

                    break;
                }
            }

            // Recalcula o subtotal, coloca a máscara de Moeda e exibe na tela
            ViewBag.SubTotal = CalculaSubTotal((IList<Negocio.Model.Produto>)Session["produtos"]).ToString("C");

            return View("Index", ((IList<Negocio.Model.Produto>)Session["produtos"]));
        }

        [HttpPost]

        // Fechar a compra dos produtos escolhidos
        public ActionResult FecharCompra(IList<int> _Quantidade)
        {
            // Verifica se existe itens no carrinho 
            if (Session["itensPedido"] != null)
            {
                for (int i = 0; i < _Quantidade.Count; i++)
                {
                    ((IList<Negocio.Model.ItemPedido>)Session["itensPedido"]).ElementAt(i)._Quantidade = _Quantidade[i];
                }                                
            }
            else
            {
                IList<Negocio.Model.ItemPedido> itensPedido = new List<Negocio.Model.ItemPedido>();

                // 
                if (Session["produtos"] != null)
                {
                    // Adiciona os itens do carrinho ao Pedido
                    for (int i = 0; i < _Quantidade.Count; i++)
                    {
                        Negocio.Model.ItemPedido itemPedido = new Negocio.Model.ItemPedido();
                        itemPedido._Produto = ((IList<Negocio.Model.Produto>)Session["produtos"]).ElementAt(i);
                        itemPedido._Quantidade = _Quantidade[i];
                        itensPedido.Add(itemPedido);
                    }
                }
                Session["itensPedido"] = itensPedido;

                Double totalCompra = Convert.ToDouble(CalculaSubTotal((IList<Negocio.Model.Produto>)Session["produtos"]));
                ViewBag.TotalCompra = totalCompra.ToString("C");
                ViewBag.TotalPagar = (totalCompra + 10.0).ToString("C");//O frete definido será de 10 reais
            }

            return View();
        }

        // Limpar Carrinho
        public ViewResult LimparCarrinho()
        {
            Session.Clear();

            // Recalcula o subtotal, coloca a máscara de Moeda e exibe na tela
            ViewBag.SubTotal = CalculaSubTotal((IList<Negocio.Model.Produto>)Session["produtos"]).ToString("C");

            return View("Index");
        }

        // Remover o item do Carrinho
        public ViewResult RemoverItem(int produtoId)
        {
            for (int i = 0; i < ((IList<Negocio.Model.Produto>)Session["produtos"]).ToList().Count; i++)
            {
                if (((IList<Negocio.Model.Produto>)Session["produtos"]).ToList()[i]._ProdutoId == produtoId)
                {
                    ((IList<Negocio.Model.Produto>)Session["produtos"]).RemoveAt(i);

                    break;
                }
            }

            ViewBag.SubTotal = CalculaSubTotal((IList<Negocio.Model.Produto>)Session["produtos"]).ToString("C");

            return View("Index", ((IList<Negocio.Model.Produto>)Session["produtos"]));
        }

        public ActionResult DadosPedido(Negocio.Model.Cliente cliente)
        {
            IList<Negocio.Model.Produto> lstProdutos = new List<Negocio.Model.Produto>();

            if(Session["itensPedido"] != null)
            {
                //Salva Cliente
                Negocio.DAO.ClienteDAO clienteDAO = new Negocio.DAO.ClienteDAO();
                clienteDAO.Insert(cliente);

                //Salva Pedido
                Negocio.DAO.PedidoDAO pedidoDAO = new Negocio.DAO.PedidoDAO();
                Negocio.Model.Pedido pedido = new Negocio.Model.Pedido();
                pedido._Cliente = clienteDAO.SelectLastCliente();
                pedido._Numero = pedido._Cliente._ClienteId + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
                pedidoDAO.Insert(pedido);
                pedido._PedidoId = pedidoDAO.SelectLastPedido()._PedidoId;

                //Salva Itens do Pedido
                Negocio.DAO.ItemPedidoDAO itemPedidoDAO = new Negocio.DAO.ItemPedidoDAO();
                Negocio.DAO.ProdutoDAO produtoDAO = new Negocio.DAO.ProdutoDAO();                
                Negocio.Model.Produto prod = new Negocio.Model.Produto();

                foreach(Negocio.Model.ItemPedido itemPedido in (List<Negocio.Model.ItemPedido>)Session["itensPedido"])
                {
                    itemPedido._Pedido = pedido;                
                    itemPedidoDAO.Insert(itemPedido);
                
                    prod = produtoDAO.SelectById(itemPedido._Produto._ProdutoId);
                    prod._Quantidade = itemPedido._Quantidade;

                    lstProdutos.Add(prod);
                }

                // Exibe as informações do Pedido na tela
                ViewBag.NumPedido = pedido._Numero;
                ViewBag.NomeCompleto = cliente._NomeCompleto;
                ViewBag.DataNascimento = cliente._DataNascimento;
                ViewBag.Endereco = cliente._Endereco;
                ViewBag.Telefone = cliente._Telefone;
                ViewBag.Email = cliente._Email;              
                ViewBag.ValorTotal = Convert.ToDouble(CalculaSubTotal((IList<Negocio.Model.Produto>)Session["produtos"])).ToString("C");

                Session.Clear();
            }

            return View(lstProdutos);
        }

        // Calcular o o Subtotal
        private Double CalculaSubTotal(IList<Negocio.Model.Produto> produtos)
        {
            Double SubTotal = 0;

            if (produtos != null)
            {
                for (int i = 0; i < produtos.Count; i++)
                {
                    int qtde = produtos.ToList().ElementAt(i)._Quantidade;
                    decimal preco = produtos.ToList().ElementAt(i)._Preco;

                    SubTotal += Convert.ToDouble(qtde * preco);

                }
            }

            return SubTotal;
        }
    }
}
