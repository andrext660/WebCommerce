using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Venda
	{
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public float ValorTotal { get; set; }
		public Boolean Pago { get; set; }
		public IEnumerable<Produto> ListaProdutos { get; set; }
	}
}