using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class CategoriaDAO
    {
        public void Insert(Model.Categoria categoria)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "insert into categoria (nome, urlImagem) values (@nome, @urlImagem)";

            command.Parameters.AddWithValue("@nome", categoria._Nome);            
            command.Parameters.AddWithValue("@urlImagem", categoria._UrlImagem);            

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Update(Model.Categoria categoria)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "update categoria set nome = @nome, urlImagem = @urlImagem where categoriaId = @categoriaId";

            command.Parameters.AddWithValue("@nome", categoria._Nome);
            command.Parameters.AddWithValue("@urlImagem", categoria._UrlImagem);              
            command.Parameters.AddWithValue("@categoriaId", categoria._CategoriaId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Delete(Model.Categoria categoria)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "delete from categoria where categoriaId = @categoriaId";

            command.Parameters.AddWithValue("@categoriaId", categoria._CategoriaId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public Model.Categoria SelectById(int categoriaId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from categoria where categoriaId = @categoriaId";
            command.Parameters.AddWithValue("@categoriaId", categoriaId);

            SqlDataReader dr = DAO.ConexaoBanco.Select(command);

            Model.Categoria categoria = new Model.Categoria();

            if (dr.HasRows)
            {
                dr.Read();

                categoria._CategoriaId = (int)dr["categoriaId"];
                categoria._Nome = (string)dr["nome"];
                categoria._UrlImagem = (string)dr["urlImagem"];
            }
            else
            {
                categoria = null;
            }

            return categoria;
        }
        
        // Selecionar todas as categorias
        public IList<Model.Categoria> SelectAll()
        {
            IList<Model.Categoria> categorias = new List<Model.Categoria>();

            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from categoria";

                SqlDataReader dr = DAO.ConexaoBanco.Select(command);
                

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Model.Categoria categoria = new Model.Categoria();
                        categoria._CategoriaId = (int)dr["categoriaId"];
                        categoria._Nome = (string)dr["nome"];
                        categoria._UrlImagem = (string)(dr["urlImagem"]);
                        categorias.Add(categoria);
                    }
                }
                else
                {
                    categorias = null;
                }

            }
            catch
            {
                return null;
            }
            return categorias;
        }        
    }
}
