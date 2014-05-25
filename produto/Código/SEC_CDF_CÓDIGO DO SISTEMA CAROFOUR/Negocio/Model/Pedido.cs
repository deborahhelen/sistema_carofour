using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Pedido
    {
        private int pedidoId;
        private int numero;
        private Cliente cliente;

        public Pedido()
        {
            cliente = new Cliente();
        }

        public int _PedidoId
        {
            get { return pedidoId; }
            set { pedidoId = value; }
        }

        public int _Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public Cliente _Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
    }
}
