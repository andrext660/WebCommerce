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
		public bool Pago { get; set; }
        public int CodCupom { get; set; }
        public int IdCliente { get; set; }

        public Cupom Cupom { get; set; }
        public virtual ICollection<Produto> ListaProdutos { get; set; }
       
	}
}