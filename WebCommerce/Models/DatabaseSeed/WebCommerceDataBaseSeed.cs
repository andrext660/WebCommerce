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