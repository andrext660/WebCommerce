using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Categoria
	{
		public Categoria()
		{
			ListaProduto = new List<Produto>();
		}
		public int Id { get; set; }
		public String Nome { get; set; }
		public String Descricao { get; set; }

		public IEnumerable<Produto> ListaProduto { get; set; }
	}
}