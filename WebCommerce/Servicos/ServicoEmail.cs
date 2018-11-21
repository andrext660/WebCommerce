using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using System.Net;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;

namespace WebCommerce.Servicos
{
    public class ServicoEmail
    {
        public static Task EnviaEmailAsync(string email, string assunto, string mensagem)
        {
            // serviço para enviar email
            var minhaMensagem = new SendGridMessage();
            minhaMensagem.AddTo(email);
            minhaMensagem.From = new MailAddress("deivizika@hotmail.com", "WebCommerce Unit");
            minhaMensagem.Subject = assunto;
            minhaMensagem.Text = mensagem;
            minhaMensagem.Html = mensagem;
            //var credenciais = new NetworkCredential("deivide.nascimento", "dg88013588");
            // Cria um transporte web para enviar email
            var transporteWeb = new Web(credenciais);
            // Envia o email
            if (transporteWeb != null)
            {
                return transporteWeb.DeliverAsync(minhaMensagem);
            }
            else
            {
                return Task.FromResult(0);
            }
        }
    }
}