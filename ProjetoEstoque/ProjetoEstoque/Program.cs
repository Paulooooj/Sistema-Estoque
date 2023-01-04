using ProjetoEstoque;
using System;
using System.Globalization;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Estoque> list = new List<Estoque>();
            Estoque est;
            bool encerrarWhile = true;
            int codigo;

            do
            {

                Console.WriteLine("1> Adicionar Produtos");
                Console.WriteLine("2> Remover Produtos ");
                Console.WriteLine("3> Aumentar quantidade de Produtos ");
                Console.WriteLine("4> Consultar Produtos");
                Console.WriteLine("5> Buscar produto por Código");
                Console.WriteLine("6> Encerrar Programa");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Quantos Produtos deseja adicionar? ");
                        int quantidadeProdutos = int.Parse(Console.ReadLine());

                        for (int i = 1; i <= quantidadeProdutos; i++)
                        {
                            Console.Write("Produto " + i + ":");
                            string nomeProduto = Console.ReadLine();
                            Console.Write("Preço: ");
                            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.Write("Codigo: ");
                            codigo = int.Parse(Console.ReadLine());
                            Console.Write("Quantidade: ");
                            int quantidade = int.Parse(Console.ReadLine());
                          
                            list.Add(new Estoque(nomeProduto, preco, codigo, quantidade));
                            Console.WriteLine();
                        }
                        Console.WriteLine("Produtos Adicionados com sucesso!!");
                        break;

                    case 2:
                        Console.Write("Informe o codigo do produto: ");
                        codigo = int.Parse(Console.ReadLine());
                        est = list.Find(x => x.Codigo == codigo);

                        if (est != null)
                        {
                            Console.Write("Informe quantos produtos devem ser removidos: ");
                            int remover = int.Parse(Console.ReadLine());
                            est.RemoverProdutos(remover);
                            if (est.Quantidade == 0)
                            {
                                Console.WriteLine("Quantidade desse produto é 0, deseja remover? (n/s)");
                                char resposta = char.Parse(Console.ReadLine());
                                if (resposta == 's' || resposta == 'S')
                                    list.Remove(est);
                                Console.WriteLine("Produto removido do Estoque!!");
                               
                            }
                            else 
                            {
                                Console.WriteLine("Quantidade Removida!!!");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case 3:
                        Console.Write("Informe o codigo do produto: ");
                        codigo = int.Parse(Console.ReadLine());
                        est = list.Find(x => x.Codigo == codigo);
                        if (est != null)
                        {
                            Console.WriteLine("Quantidade a ser adicionada");
                            int add = int.Parse(Console.ReadLine());
                            est.AdicionarQuantidade(add);
                            Console.WriteLine("Quantidade adicionada com sucesso!!");
                            Console.WriteLine();
                        }
                        break;

                    case 4:
                        Console.WriteLine();
                        if (list.Count != 0)
                        {
                            foreach (Estoque estoque in list)
                            {
                                Console.WriteLine(estoque);
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum produto cadastrado!!");
                            Console.WriteLine();
                        }
                        break;

                    case 5:
                        Console.WriteLine();
                        if (list.Count != 0)
                        {
                            Console.Write("Informe o codigo do produto: ");
                            codigo = int.Parse(Console.ReadLine());
                            est = list.Find(x => x.Codigo == codigo);
                            Console.WriteLine(est);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Nenhum produto cadastrado!!");
                        }

                        break;

                    case 6:
                        encerrarWhile = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!!! Tentar Novamente ");
                        break;

                }
            } while (encerrarWhile);
            Console.WriteLine("Sistema encerrado!!");
        }
    }
}