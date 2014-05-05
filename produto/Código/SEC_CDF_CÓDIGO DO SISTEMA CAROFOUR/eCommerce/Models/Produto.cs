using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.Models
{
    public class Produto
    {
        public Produto(int codProduto, string nome, string descricao, double preco)
        {
            CodProduto = codProduto;
            NomeProduto = nome;
            Descricao = descricao;
            Preco = preco;
        }
       
        public int CodProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public double Preco { get; set; }
        public int CodCategoria { get; set; }

    }
}