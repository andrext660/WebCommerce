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
			ListaCategoria = new List<Categoria>();
		}
		public int Id { get; set; }
		public String Nome { get; set; }
		public String Descricao { get; set; }

		public IEnumerable<Categoria> ListaCategoria { get; set; }
	}
}