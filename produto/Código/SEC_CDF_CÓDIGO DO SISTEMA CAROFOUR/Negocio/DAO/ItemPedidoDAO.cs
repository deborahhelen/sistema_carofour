using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class ItemPedidoDAO
    {
        public void Insert(Model.ItemPedido itemPedido)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "insert into itemPedido (quantidade, pedidoId, produtoId) values (@quantidade, @pedidoId, @produtoid)";

            command.Parameters.AddWithValue("@quantidade", itemPedido._Quantidade);
            command.Parameters.AddWithValue("@pedidoId", itemPedido._Pedido._PedidoId);
            command.Parameters.AddWithValue("@produtoId", itemPedido._Produto._ProdutoId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Update(Model.ItemPedido itemPedido)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "update itemPedido set quantidade = @quantidade, pedidoId = @pedidoId, produtoId = @produtoId where itemPedidoId = @itemPedidoId";

            command.Parameters.AddWithValue("@quantidade", itemPedido._Quantidade);
            command.Parameters.AddWithValue("@pedidoId", itemPedido._Pedido._PedidoId);
            command.Parameters.AddWithValue("@produtoId", itemPedido._Produto._ProdutoId);
            command.Parameters.AddWithValue("@itemPedidoId", itemPedido._ItemPedidoId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Delete(Model.ItemPedido itemPedido)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "delete from itemPedido where itemPedidoId = @itemPedidoId";

            command.Parameters.AddWithValue("@itemPedidoId", itemPedido._ItemPedidoId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public Model.ItemPedido SelectById(int itemPedidoId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from itemPedidoId where itemPedidoId = @itemPedidoId";
            command.Parameters.AddWithValue("@itemPedidoId", itemPedidoId );

            SqlDataReader dr = DAO.ConexaoBanco.Select(command);

            Model.ItemPedido itemPedido = new Model.ItemPedido();
            PedidoDAO pedido = new PedidoDAO();
            ProdutoDAO produto = new ProdutoDAO();

            if (dr.HasRows)
            {
                dr.Read();

                itemPedido._ItemPedidoId = (int)dr["itemPedidoId"];
                itemPedido._Pedido = pedido.SelectById((int)dr["pedidoid"]);
                itemPedido._Produto = produto.SelectById((int)dr["produtoId"]);
                itemPedido._Quantidade = (int)dr["quantidade"];
            }
            else
            {
                itemPedido = null;
            }

            return itemPedido;
        }

        public IList<Model.ItemPedido> SelectByTitle(int itemPedidoid)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from itemPedido where itemPedidoId = @itemPedidoId";
            command.Parameters.AddWithValue("@itemPedido", itemPedidoid);

            SqlDataReader dr = DAO.ConexaoBanco.Select(command);
            IList<Model.ItemPedido> itemPedidos = new List<Model.ItemPedido>();
            PedidoDAO pedido = new PedidoDAO();
            ProdutoDAO produto = new ProdutoDAO();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Model.ItemPedido itemPedido = new Model.ItemPedido();
                    itemPedido._ItemPedidoId = (int)dr["itemPedidoId"];
                    itemPedido._Pedido = pedido.SelectById((int)dr["nome"]);
                    itemPedido._Produto = produto.SelectById((int)dr["produtoId"]);
                    itemPedidos.Add(itemPedido);
                }
            }
            else
            {
                itemPedidos = null;
            }

            return itemPedidos;
        }
    }
}
