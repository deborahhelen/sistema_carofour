using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Categoria
    {
        private int categoriaId;
        private string nome;
        private string urlImagem;

        public int _CategoriaId
        {
            get { return categoriaId; }
            set { categoriaId = value; }
        }

        public string _Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string _UrlImagem
        {
            get { return urlImagem;}
            set { urlImagem = value; }
        }
    }
}
