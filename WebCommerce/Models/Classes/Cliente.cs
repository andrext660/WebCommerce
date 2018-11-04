using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Cliente
	{


        public Cliente()
        {
            ListaVenda = new List<Venda>();
        }




        public int Id { get; set; }
		public String Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public String CPF { get; set; }
		public String Telefone { get; set; }
		public int? IdEndereco { get; set; }
		public Endereco Endereco { get; set; }


        public IEnumerable<Venda> ListaVenda { get; set; }


    }
}