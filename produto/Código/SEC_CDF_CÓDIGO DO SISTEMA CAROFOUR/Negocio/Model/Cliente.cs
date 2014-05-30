using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Cliente
    {
        private int clienteId;
        private string nomeCompleto;        
        private string email;
        private string senha;
        private DateTime dataNascimento;
        private string sexo;
        private string endereco;
        private string telefone;
        

        public int _ClienteId
        {
            get { return clienteId; }
            set { clienteId = value; }
        }

        public string _NomeCompleto
        {
            get { return nomeCompleto; }
            set { nomeCompleto = value; }
        }

        public string _Email
        {
            get { return email; }
            set { email = value; }
        }        

        public string _Senha
        {
            get { return senha; }
            set { senha = value; }
        }        

        public DateTime _DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }        

        public string _Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }        

        public string _Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }        

        public string _Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        
    }
}
