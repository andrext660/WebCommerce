using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Cliente
	{

        public int Id { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public string CPF { get; set; }
		public string Telefone { get; set; }
		public int? IdEndereco { get; set; }
		public Endereco Endereco { get; set; }

        public virtual ICollection<Venda> ListaVenda { get; set; }
        public virtual ICollection<Cupom> ListaCupom { get; set; }

        public Cliente()
        {
            this.ListaVenda = new List<Venda>();
            this.ListaCupom = new List<Cupom>();
        }
    }
}