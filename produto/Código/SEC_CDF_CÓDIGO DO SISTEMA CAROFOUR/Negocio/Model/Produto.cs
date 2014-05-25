using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Produto
    {
        private int produtoId;
        private string nome;
        private string descricao;
        private decimal preco;
        private string urlImagem;
        private Categoria categoria;
        private int quantidade;
        
        public Produto()
        {
            categoria = new Categoria();
        }

        public int _ProdutoId
        {
            get { return produtoId; }
            set { produtoId = value; }
        }        

        public string _Nome
        {
            get { return nome; }
            set { nome = value; }
        }        

        public string _Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }        

        public decimal _Preco
        {
            get { return preco; }
            set { preco = value; }
        }        

        public string _UrlImagem
        {
            get { return urlImagem; }
            set { urlImagem = value; }
        }        

        public Categoria _Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public int _Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

    }
}
