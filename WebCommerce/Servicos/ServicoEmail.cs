using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using System.Net;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;

//Aqui está o usuario e senha para enviar email
//Usuário: webcomerce.unit
//Senha: unit1234

namespace WebCommerce.Servicos
{
    public class ServicoEmail
    {
        public static Task EnviarEmailAsync(string email, string assunto, string mensagem)
        {
            //serviço para enviar email
            var minhaMensagem = new SendGridMessage();
            minhaMensagem.AddTo(email);
            minhaMensagem.From = new MailAddress("webcommerce.unit@outlook.com", "WebCommerce Unit");
            minhaMensagem.Subject = assunto;
            minhaMensagem.Text = mensagem;
            minhaMensagem.Html = mensagem;
            var credenciais = new NetworkCredential("Usuario aqui", "Senha aqui");
            
            //Cria um transporte web para enviar email
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