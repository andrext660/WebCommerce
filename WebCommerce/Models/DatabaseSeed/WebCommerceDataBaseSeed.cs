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
						Cliente cliente = new Cliente();
						Cupom cupom = new Cupom();
						Endereco endereco = new Endereco();
						Produto produto = new Produto();
                        Produto produto1 = new Produto();
                        Produto produto2 = new Produto();
                        Produto produto3 = new Produto();
                        Produto produto4 = new Produto();
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
                        produto4.Preco = 200;
                        produto4.Promocao = promocao;
                        produto4.Categoria = categoria;
                        produto4.Detalhes = "Esse mouse é pra gamer apenas 20000DPI";
                        produto4.QuantidadeDisponivel = 20;
                        contexto.Produtoes.Add(produto4);

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