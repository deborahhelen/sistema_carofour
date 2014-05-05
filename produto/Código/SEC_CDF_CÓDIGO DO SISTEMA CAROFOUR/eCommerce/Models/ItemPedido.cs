using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.Models
{
    public class ItemPedido
    {
        public int Quantidade { get; set; }
        public int CodProduto { get; set; }
        public double ValorProduto { get; set; }
    }
}