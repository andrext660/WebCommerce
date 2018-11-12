using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Endereco
	{
		public int Id { get; set; }
		public String CEP { get; set; }
		public String Rua { get; set; }		
		public String Bairro { get; set; }
		public String Cidade { get; set; }
		public String Estado { get; set; }
		public int Numero { get; set; }
	}
}