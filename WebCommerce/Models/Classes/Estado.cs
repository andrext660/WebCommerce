using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Estado
	{
		public int Id { get; set; }
		public String Nome { get; set; }
		public String Sigla { get; set; }
        public virtual IList<Endereco> ListaEndereco { get; set; }
    }
}