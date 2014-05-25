using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.Models
{
    public class Produto
    {
        private int produtoId;
        private bool isChecked;

        public int _ProdutoId
        {
            get { return produtoId; }
            set { produtoId = value; }
        }        

        public bool _IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

    }
}