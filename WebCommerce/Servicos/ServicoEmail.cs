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
            //serviço paraenviar email
            var minhaMensagem = new SendGridMessage();
            minhaMensagem.AddTo(email);
<<<<<<< HEAD
            minhaMensagem.From = new MailAddress("webcommerce.unit@outlook.com", "WebCommerce Unit");
            minhaMensagem.Subject = assunto;
            minhaMensagem.Text = mensagem;
            minhaMensagem.Html = mensagem;
            var credenciais = new NetworkCredential("Usuario aqui", "Senha aqui");
            //Cria um transporte web para enviar email
=======
            minhaMensagem.From = new MailAddress("deivizika@hotmail.com", "Deivide Mateus");
            minhaMensagem.Subject = assunto;
            minhaMensagem.Text = mensagem;
            minhaMensagem.Html = mensagem;
            var credenciais = new NetworkCredential("deivide_mateus","dg88013588");
            //Cria um transporte web para enviar email
            var transportWeb = new Web(credenciais);
            // Cria um transporte web para enviar email
>>>>>>> parent of c3f58df... Merge branch 'master' of https://github.com/andrext660/WebCommerce
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