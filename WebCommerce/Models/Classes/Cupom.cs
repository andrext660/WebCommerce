using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCommerce.Models.Classes
{
	public class Cupom
	{
        

        public int Id { get; set; }
        //public int Codigo { get; set; }
		public int DescontoPorcentagem { get; set; }
		public bool Valido { get; set; }
		public int Quantidade { get; set; }
		public string Descricao { get; set; }
        
        }


    }