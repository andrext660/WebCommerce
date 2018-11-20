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
        public static Task EnviarEmailAsync(string email, string assunto, string mensagem)
        {
            //serviço paraenviar email
            var minhaMensagem = new SendGridMessage();
            minhaMensagem.AddTo(email);
            minhaMensagem.From = new MailAddress("deivizika@hotmail.com", "Deivide Mateus");
            minhaMensagem.Subject = assunto;
            minhaMensagem.Text = mensagem;
            minhaMensagem.Html = mensagem;
            var credenciais = new NetworkCredential("deivide_mateus","dg88013588");
            //Cria um transporte web para enviar email
            var transportWeb = new Web(credenciais);
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