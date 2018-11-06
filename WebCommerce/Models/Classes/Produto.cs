using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Produto
	{
		public int Id { get; set; }
		public String Nome { get; set; }
		public float Preco { get; set; }
		public int QuantidadeDisponivel { get; set; }
		public String Detalhes { get; set; }
		public int? IdCategoria { get; set; }
		public Categoria Categoria { get; set; }
		public int? IdPromocao { get; set; }
		public Promocao Promocao { get; set; }
	}
}