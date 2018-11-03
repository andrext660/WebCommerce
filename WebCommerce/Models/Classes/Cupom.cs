using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Cupom
	{
		public int Codigo { get; set; }
		public float DescontoQuantidade { get; set; }
		public int DescontoPorcentagem { get; set; }
		public Boolean Valido { get; set; }
		public int Quantidade { get; set; }
		public String Descricao { get; set; }
	}
}