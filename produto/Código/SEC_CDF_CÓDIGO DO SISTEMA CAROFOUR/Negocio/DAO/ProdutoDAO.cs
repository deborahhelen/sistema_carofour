using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class ProdutoDAO
    {
        public void Insert(Model.Produto produto)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "insert into produto (nome, descricao, preco, urlImagem, categoriaId) values " +
                                  "(@nome, @descricao, @preco, @urlImagem, @categoriaId)";

            command.Parameters.AddWithValue("@nome", produto._Nome);
            command.Parameters.AddWithValue("@descricao", produto._Descricao);
            command.Parameters.AddWithValue("@preco", produto._Preco);
            command.Parameters.AddWithValue("@urlImagem", produto._UrlImagem);
            command.Parameters.AddWithValue("@categoriaId", produto._Categoria._CategoriaId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Update(Model.Produto produto)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "update produto set nome = @nome, descricao = @descricao, preco = @preco, urlImagem = @urlImagem, categoria = @categoria where livroId = @livroId";

            command.Parameters.AddWithValue("@nome", produto._Nome);
            command.Parameters.AddWithValue("@descricao", produto._Descricao);
            command.Parameters.AddWithValue("@preco", produto._Preco);
            command.Parameters.AddWithValue("@urlImagem", produto._UrlImagem);
            command.Parameters.AddWithValue("@categoriaId", produto._Categoria._CategoriaId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Delete(Model.Produto produto)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "delete from produto where produtoId = @produtoId";

            command.Parameters.AddWithValue("@produtoId", produto._ProdutoId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public Model.Produto SelectById(int produtoId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from produto where produtoId = @produtoId";
            command.Parameters.AddWithValue("@produtoId", produtoId);

            SqlDataReader dr = ConexaoBanco.Select(command);            

            Model.Produto produto = new Model.Produto();
            DAO.CategoriaDAO categoria = new CategoriaDAO();

            if (dr.HasRows)
            {
                dr.Read();

                produto._ProdutoId = (int)dr["produtoId"];
                produto._Categoria = categoria.SelectById((int)dr["categoriaId"]);
                produto._Descricao = (string)dr["descricao"];
                produto._Nome = (string)dr["nome"];
                produto._Preco = (decimal)dr["preco"];
                produto._UrlImagem = (string)dr["urlImagem"];
            }
            else
            {
                produto = null;
            }

            return produto;
        }

        public IList<Model.Produto> SelectByCategoria(int? categoriaId)
        {
            IList<Model.Produto> produtos = new List<Model.Produto>();

            if (categoriaId != null)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from produto where categoriaId = @categoriaId";
                command.Parameters.AddWithValue("@categoriaId", categoriaId);

                SqlDataReader dr = DAO.ConexaoBanco.Select(command);                
                DAO.CategoriaDAO categoria = new CategoriaDAO();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Model.Produto produto = new Model.Produto();
                        produto._ProdutoId = (int)dr["produtoId"];
                        produto._Categoria = (Model.Categoria)categoria.SelectById((int)dr["categoriaId"]);
                        produto._Descricao = (string)dr["descricao"];
                        produto._Nome = (string)dr["nome"];
                        produto._Preco = (decimal)dr["preco"];
                        produto._UrlImagem = (string)dr["urlImagem"];
                        produtos.Add(produto);
                    }
                }
                else
                {
                    produtos = null;
                }
            }
            else
            {
                produtos = null;
            }

            return produtos;
        }
    }
}
