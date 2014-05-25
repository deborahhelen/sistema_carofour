using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class ClienteDAO
    {
        public void Insert(Model.Cliente cliente)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "insert into cliente (email, senha, dataNascimento, sexo, endereco, telefone, nomeCompleto) values (@email, @senha, @dataNascimento, @sexo, @endereco, @telefone, @nomeCompleto)";

            command.Parameters.AddWithValue("@email", cliente._Email);
            command.Parameters.AddWithValue("@senha", cliente._Senha);
            command.Parameters.AddWithValue("@dataNascimento", cliente._DataNascimento);
            command.Parameters.AddWithValue("@sexo", cliente._Sexo);
            command.Parameters.AddWithValue("@endereco", cliente._Endereco);
            command.Parameters.AddWithValue("@telefone", cliente._Telefone);
            command.Parameters.AddWithValue("@nomeCompleto", cliente._NomeCompleto);

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Update(Model.Cliente cliente)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "update cliente set email = @email, senha = @senha, dataNascimento = @dataNascimento, sexo = @sexo, endereco = @endereco, telefone = @telefone, nomeCompleto = @nomeCompleto where clienteId = @clienteId";

            command.Parameters.AddWithValue("@email", cliente._Email);
            command.Parameters.AddWithValue("@senha", cliente._Senha);
            command.Parameters.AddWithValue("@dataNascimento", cliente._DataNascimento);
            command.Parameters.AddWithValue("@sexo", cliente._Sexo);
            command.Parameters.AddWithValue("@endereco", cliente._Endereco);
            command.Parameters.AddWithValue("@telefone", cliente._Telefone);
            command.Parameters.AddWithValue("@nomeCompleto", cliente._NomeCompleto);            

            DAO.ConexaoBanco.CRUD(command);
        }

        public void Delete(Model.Cliente cliente)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "delete from cliente where clienteId = @clienteId";

            command.Parameters.AddWithValue("@clienteId", cliente._ClienteId);

            DAO.ConexaoBanco.CRUD(command);
        }

        public Model.Cliente SelectById(int clienteId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from cliente where clienteId = @clienteId";
            command.Parameters.AddWithValue("@clienteId", clienteId);

            SqlDataReader dr = DAO.ConexaoBanco.Select(command);

            Model.Cliente cliente = new Model.Cliente();

            if (dr.HasRows)
            {
                dr.Read();

                cliente._ClienteId = (int)dr["clienteId"];
                cliente._Email = (string)dr["email"];
                cliente._Senha = (string)dr["senha"];
                cliente._DataNascimento = (DateTime)dr["dataNascimento"];
                cliente._Sexo = (string)dr["sexo"];
                cliente._Endereco = (string)dr["endereco"];
                cliente._Telefone = (string)dr["telefone"];
                cliente._NomeCompleto = (string)dr["nomeCompleto"];
            }
            else
            {
                cliente = null;
            }

            return cliente;
        }

        public IList<Model.Cliente> SelectByTitle(string name)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from cliente where nomeCompleto = @nomeCompleto";
            command.Parameters.AddWithValue("@noeCompleto", "'%" + name + "%'");

            SqlDataReader dr = DAO.ConexaoBanco.Select(command);
            IList<Model.Cliente> clientes = new List<Model.Cliente>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Model.Cliente cliente = new Model.Cliente();
                    cliente._ClienteId = (int)dr["clienteId"];
                    cliente._Email = (string)dr["email"];
                    cliente._Senha = (string)dr["senha"];
                    cliente._DataNascimento = (DateTime)dr["dataNascimento"];
                    cliente._Sexo = (string)dr["sexo"];
                    cliente._Endereco = (string)dr["endereco"];
                    cliente._Telefone = (string)dr["telefone"];
                    cliente._NomeCompleto = (string)dr["nomeCompleto"];                    
                    clientes.Add(cliente);
                }
            }
            else
            {
                clientes = null;
            }

            return clientes;
        }

        public Model.Cliente SelectLastCliente()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from cliente where clienteId = (select MAX(clienteId) from cliente)";            

            SqlDataReader dr = DAO.ConexaoBanco.Select(command);

            Model.Cliente cliente = new Model.Cliente();

            if (dr.HasRows)
            {
                dr.Read();

                cliente._ClienteId = (int)dr["clienteId"];
                cliente._Email = (string)dr["email"];
                cliente._Senha = (string)dr["senha"];
                cliente._DataNascimento = (DateTime)dr["dataNascimento"];
                cliente._Sexo = (string)dr["sexo"];
                cliente._Endereco = (string)dr["endereco"];
                cliente._Telefone = (string)dr["telefone"];
                cliente._NomeCompleto = (string)dr["nomeCompleto"];
            }
            else
            {
                cliente = null;
            }

            return cliente;
        }
    }
}
