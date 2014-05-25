using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class PedidoDAO
    {
        public void Insert(Model.Pedido pedido)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "insert into pedido (numero, clienteId) values (@numero, @clienteId)";

            command.Parameters.AddWithValue("@numero", pedido._Numero);
            command.Parameters.AddWithValue("@clienteId", pedido._Cliente._ClienteId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Update(Model.Pedido pedido)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "update pedido set numero = @numero, clienteId = @clienteId where pedidoId = @pedidoId";

            command.Parameters.AddWithValue("@numero", pedido._Numero);
            command.Parameters.AddWithValue("@clienteId", pedido._Cliente._ClienteId);
            command.Parameters.AddWithValue("@pedidoId", pedido._PedidoId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Delete(Model.Pedido pedido)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "delete from pedido where pedidoId = @pedidoId";

            command.Parameters.AddWithValue("@pedidoId", pedido._PedidoId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public Model.Pedido SelectById(int pedidoId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from pedido where pedidoId = @pedidoId";
            command.Parameters.AddWithValue("@pedidoId", pedidoId);

            SqlDataReader dr = DAO.ConexaoBanco.Select(command);

            Model.Pedido pedido = new Model.Pedido();
            ClienteDAO cliente = new ClienteDAO();

            if (dr.HasRows)
            {
                dr.Read();

                pedido._PedidoId = (int)dr["pedidoId"];
                pedido._Numero = (int)dr["numero"];
                pedido._Cliente = cliente.SelectById((int)dr["clienteId"]);
            }
            else
            {
                pedido = null;
            }

            return pedido;
        }

        public IList<Model.Pedido> SelectByTitle(int numero)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from Pedido where numero = @numero";
            command.Parameters.AddWithValue("@nome", numero);

            SqlDataReader dr = DAO.ConexaoBanco.Select(command);
            IList<Model.Pedido> pedidos = new List<Model.Pedido>();
            ClienteDAO cliente = new ClienteDAO();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Model.Pedido pedido = new Model.Pedido();
                    pedido._PedidoId = (int)dr["pedidoId"];
                    pedido._Numero = (int)dr["numero"];
                    pedido._Cliente = cliente.SelectById((int)dr["clienteId"]);
                    pedidos.Add(pedido);
                }
            }
            else
            {
                pedidos = null;
            }

            return pedidos;
        }

        public Model.Pedido SelectLastPedido()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from pedido where pedidoId = (select MAX(pedidoId) from pedido)";            

            SqlDataReader dr = DAO.ConexaoBanco.Select(command);

            Model.Pedido pedido = new Model.Pedido();
            ClienteDAO cliente = new ClienteDAO();

            if (dr.HasRows)
            {
                dr.Read();

                pedido._PedidoId = (int)dr["pedidoId"];
                pedido._Numero = (int)dr["numero"];
                pedido._Cliente = cliente.SelectById((int)dr["clienteId"]);
            }
            else
            {
                pedido = null;
            }

            return pedido;
        }
    }
}
