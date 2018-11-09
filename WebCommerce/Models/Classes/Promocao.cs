using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Promocao
	{
		public int Id { get; set; }
		public int DescontoPorcentagem { get; set; }
		//public float DescontoQuantidade { get; set; }
		public DateTime DataPrazo { get; set; }
		public Boolean Valido { get; set; }
		public String Descricao { get; set; }
	}
}