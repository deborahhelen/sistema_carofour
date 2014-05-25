using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class ItemPedido
    {
        private int itemPedidoId;
        private int quantidade;
        private Pedido pedido;
        private Produto produto;

        public ItemPedido()
        {
            pedido = new Pedido();
            produto = new Produto();
        }

        public int _ItemPedidoId
        {
            get { return itemPedidoId; }
            set { itemPedidoId = value; }
        }        

        public int _Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }        

        public Pedido _Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }        

        public Produto _Produto
        {
            get { return produto; }
            set { produto = value; }
        }


    }
}
