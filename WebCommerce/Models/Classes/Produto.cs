using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace WebCommerce.Models.Classes
{
	public class Produto
	{
		public Produto()
		{
			this.ListaVendas = new List<Venda>();
		}

		public int Id { get; set; }
		public string Nome { get; set; }
		public float Preco { get; set; }
		public int QuantidadeDisponivel { get; set; }
		public string Detalhes { get; set; }
		public int? IdCategoria { get; set; }
		public Categoria Categoria { get; set; }
		public int? IdPromocao { get; set; }
		public Promocao Promocao { get; set; }

		public ICollection<Venda> ListaVendas{ get; set; }
	}
}