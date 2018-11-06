using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Venda
	{
        public Venda()
        {
            ListaProdutos = new List<Produto>();
        }
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public float ValorTotal { get; set; }
		public Boolean Pago { get; set; }
        public String CodCupom { get; set; }
        public IEnumerable<Produto> ListaProdutos { get; set; }
       
	}
}