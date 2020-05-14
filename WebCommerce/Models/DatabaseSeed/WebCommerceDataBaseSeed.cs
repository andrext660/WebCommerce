using System.Data.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCommerce.Models.Classes;

namespace WebCommerce.Models.DatabaseSeed
{
    public class ClinicaDataBaseSeed :
        DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            using (ApplicationDbContext contexto = new ApplicationDbContext())
            {
                using (var dbTransaction = contexto.Database.BeginTransaction())
                {
                    try
                    {
						//Criado um objeto de cada entidade
						Categoria categoria = new Categoria();
                        Categoria categoria2 = new Categoria();
						Cliente cliente = new Cliente();
						Cupom cupom = new Cupom();
						Endereco endereco = new Endereco();
						Produto produto = new Produto();
                        Produto produto1 = new Produto();
                        Produto produto2 = new Produto();
                        Produto produto3 = new Produto();
                        Produto produto4 = new Produto();
                        Produto produto5 = new Produto();
                        Produto produto6 = new Produto();
                        Produto produto7 = new Produto();
                        Produto produto8 = new Produto();
                        Produto produto9 = new Produto();
                        Produto produto10 = new Produto();
                        Produto produto11 = new Produto();
                        Promocao promocao = new Promocao();
						Venda venda = new Venda();
						
						cupom.DescontoPorcentagem = 10;
						cupom.Descricao = "Desconto Teste";
						cupom.Quantidade = 7;
						cupom.Valido = true;
						contexto.Cupoms.Add(cupom);

						categoria.Nome = "Computador Gamer";
						categoria.Descricao = "Computadores com especificações técnicas mais avançadas";
						contexto.Categorias.Add(categoria);

                        categoria2.Nome = "Eletroeletrônicos";
                        categoria2.Descricao = "Eletros em Geral";
                        contexto.Categorias.Add(categoria2);

                        promocao.DataPrazo = DateTime.Parse("25/12/2018");
						promocao.DescontoPorcentagem = 5;
						promocao.Descricao = "Desconto Teste";
						promocao.Valido = true;
						contexto.Promocaos.Add(promocao);

						context.SaveChanges();

						venda.IdCliente = cliente.Id;
						contexto.Vendas.Add(venda);

						context.SaveChanges();

						//Implementado as infomrações do endereco e salvo no contexto
						endereco.Bairro = "Aruana";
						endereco.CEP = "49038443";
						endereco.Cidade = "Aracaju";
						endereco.Numero = 4000;
						endereco.Rua = "Avenida Melicio Machado";
						endereco.UF = "SE";
						contexto.Enderecoes.Add(endereco);
						//Realizado o savechanges para salvar o endereco e poder inclui-lo no cliente
						contexto.SaveChanges();

						cliente.CPF = "07177972528";
						cliente.DataNascimento = DateTime.Parse("18/04/1997");
						cliente.Endereco = endereco;
						cliente.IdEndereco = endereco.Id;
						cliente.Nome = "Raffael";
						cliente.Telefone = "991554964";
						contexto.Clientes.Add(cliente);

						produto.IdCategoria = categoria.Id;
						produto.IdPromocao = promocao.Id;
						produto.Nome = "PC GAMER GTX";
						produto.Preco = 4500;
						produto.Promocao = promocao;
						produto.Categoria = categoria;
						produto.Detalhes = "Esse pc é pra gamer apenas, sai xiu";
						produto.QuantidadeDisponivel = 10;
						contexto.Produtoes.Add(produto);

						contexto.SaveChanges();

                        produto1.IdCategoria = categoria.Id;
                        produto1.IdPromocao = promocao.Id;
                        produto1.Nome = "Alien Ware Ggamer";
                        produto1.Preco = 4000;
                        produto1.Promocao = promocao;
                        produto1.Categoria = categoria;
                        produto1.Detalhes = "Esse Notebook é pra gamer apenas, topado";
                        produto1.QuantidadeDisponivel = 5;
                        contexto.Produtoes.Add(produto1);

                        contexto.SaveChanges();

                        produto2.IdCategoria = categoria.Id;
                        produto2.IdPromocao = promocao.Id;
                        produto2.Nome = "Monitor Ggamer";
                        produto2.Preco = 1200;
                        produto2.Promocao = promocao;
                        produto2.Categoria = categoria;
                        produto2.Detalhes = "Esse Monitor é pra gamer apenas, topado";
                        produto2.QuantidadeDisponivel = 5;
                        contexto.Produtoes.Add(produto2);

                        contexto.SaveChanges();

                        produto3.IdCategoria = categoria.Id;
                        produto3.IdPromocao = promocao.Id;
                        produto3.Nome = "Teclado Gamer";
                        produto3.Preco = 100;
                        produto3.Promocao = promocao;
                        produto3.Categoria = categoria;
                        produto3.Detalhes = "Esse Teclado é pra gamer apenas 20000DPI";
                        produto3.QuantidadeDisponivel = 30;
                        contexto.Produtoes.Add(produto3);

                        contexto.SaveChanges();

                        produto4.IdCategoria = categoria.Id;
                        produto4.IdPromocao = promocao.Id;
                        produto4.Nome = "Mouse Razer Gamer";
                        produto4.Preco = 4534;
                        produto4.Promocao = promocao;
                        produto4.Categoria = categoria;
                        produto4.Detalhes = "Esse mouse é pra gamer apenas 20000DPI";
                        produto4.QuantidadeDisponivel = 250;
                        contexto.Produtoes.Add(produto4);

                        contexto.SaveChanges();

                        produto5.IdCategoria = categoria.Id;
                        produto5.IdPromocao = promocao.Id;
                        produto5.Nome = "Mouse Razer Gamer";
                        produto5.Preco = 3698;
                        produto5.Promocao = promocao;
                        produto5.Categoria = categoria;
                        produto5.Detalhes = "Esse mouse é pra gamer apenas 20000DPI";
                        produto5.QuantidadeDisponivel = 210;
                        contexto.Produtoes.Add(produto5);

                        contexto.SaveChanges();

                        produto6.IdCategoria = categoria.Id;
                        produto6.IdPromocao = promocao.Id;
                        produto6.Nome = "Mouse Razer Gamer";
                        produto6.Preco = 2010;
                        produto6.Promocao = promocao;
                        produto6.Categoria = categoria;
                        produto6.Detalhes = "Esse mouse é pra gamer apenas 20000DPI";
                        produto6.QuantidadeDisponivel = 230;
                        contexto.Produtoes.Add(produto6);

                        contexto.SaveChanges();

                        produto7.IdCategoria = categoria.Id;
                        produto7.IdPromocao = promocao.Id;
                        produto7.Nome = "Mouse Razer Gamer";
                        produto7.Preco = 2050;
                        produto7.Promocao = promocao;
                        produto7.Categoria = categoria;
                        produto7.Detalhes = "Esse mouse é pra gamer apenas 20000DPI";
                        produto7.QuantidadeDisponivel = 240;
                        contexto.Produtoes.Add(produto7);

                        contexto.SaveChanges();

                        produto8.IdCategoria = categoria.Id;
                        produto8.IdPromocao = promocao.Id;
                        produto8.Nome = "Mouse Razer Gamer";
                        produto8.Preco = 2800;
                        produto8.Promocao = promocao;
                        produto8.Categoria = categoria;
                        produto8.Detalhes = "Esse mouse é pra gamer apenas 20000DPI";
                        produto8.QuantidadeDisponivel = 260;
                        contexto.Produtoes.Add(produto8);

                        contexto.SaveChanges();

                        produto9.IdCategoria = categoria.Id;
                        produto9.IdPromocao = promocao.Id;
                        produto9.Nome = "Mouse Razer Gamer";
                        produto9.Preco = 2060;
                        produto9.Promocao = promocao;
                        produto9.Categoria = categoria;
                        produto9.Detalhes = "Esse mouse é pra gamer apenas 20000DPI";
                        produto9.QuantidadeDisponivel = 70;
                        contexto.Produtoes.Add(produto9);

                        contexto.SaveChanges();


                        produto10.IdCategoria = categoria2.Id;
                        produto10.IdPromocao = promocao.Id;
                        produto10.Nome = "Televisão";
                        produto10.Preco = 1599;
                        produto10.Promocao = promocao;
                        produto10.Categoria = categoria2;
                        produto10.Detalhes = "Televisão 29 polegadas";
                        produto10.QuantidadeDisponivel = 10;
                        contexto.Produtoes.Add(produto10);

                        contexto.SaveChanges();

                        produto11.IdCategoria = categoria2.Id;
                        produto11.IdPromocao = promocao.Id;
                        produto11.Nome = "MicroSystem Sony";
                        produto11.Preco = 2999;
                        produto11.Promocao = promocao;
                        produto11.Categoria = categoria2;
                        produto11.Detalhes = "MicroSystem de 70 Watts, Potência e Qualidade";
                        produto11.QuantidadeDisponivel = 10;
                        contexto.Produtoes.Add(produto11);

                        contexto.SaveChanges();



                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        dbTransaction.Commit();
                    }

                }

            }
            base.Seed(context);

        }
    }
}