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
			this.ListaProdutos = new Dictionary<Produto, int>();
			this.Data = DateTime.Now;
			this.Pago = false;
			this.ValorTotal = 0;
			this.CodCupom = 0;
		}
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public float ValorTotal { get; set; }
		public bool Pago { get; set; }
        public int CodCupom { get; set; }
        public int IdCliente { get; set; }

        public Cupom Cupom { get; set; }
        public virtual IDictionary<Produto, int> ListaProdutos { get; set; }

		public void atualizarQuantidade(int quantidade, Produto produto)
		{
			this.ListaProdutos[produto] = quantidade;
		}
       
	}
}