
using MercadoConsole_POO.Models;

namespace MercadoConsole_POO.Services
{
    public class ProdutoService
    {
        private List<IProduto> produtos = new List<IProduto>();
        private int proximoId = 1;

        public ProdutoService()
        {
            produtos.Add(new Produto { Id = proximoId++, Nome = "Panela", Price = 30.50m });
            produtos.Add(new ProdutoPerecivel { Id = proximoId++, Nome = "Café", Price = 50.50m, DataValidade = DateTime.Today.AddDays(50) });
        }

        public void ListarProduto()
        {
            Console.WriteLine("\n --- Lista de Produtos ---");
            if (!produtos.Any())
            {
                Console.WriteLine("Nenhum produto cadastrado");
                return;
            }

            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }

        public void AdicionarProduto()
        {
            Console.WriteLine("\nTipo do produto: " +
                "\n1. Comum" +
                "\n2. Perecível" +
                "Escolha: ");
            string tipo = Console.ReadLine();

            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Preço: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço invalido");
                return;
            }

            if (tipo == "1")
            {
                produtos.Add(new Produto { Id = proximoId++, Nome = nome, Price = preco });
            }
            else if (tipo == "2")
            {
                Console.WriteLine("Data de Validade (dd/MM/yyyy)");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime validade))
                {
                    Console.WriteLine("Data inválida!");
                    return;
                }

                produtos.Add(new ProdutoPerecivel
                {
                    Id = proximoId++,
                    Nome = nome,
                    Price = preco,
                    DataValidade = validade
                });
            }
            else
            {
                Console.WriteLine("Tipo Inválido");
                return;
            }

            Console.WriteLine("Produto Adicionado");
        }

        public void AtualizarProduto()
        {
            Console.WriteLine("\nID do Produto para atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido");
                return;
            }

            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado");
                return;
            }

            Console.Write("Novo nome: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Novo Preço: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido");
                return;
            }

            produto.Price = preco;

            if (produto is ProdutoPerecivel perecivel)
            {
                Console.Write("Nova validade (dd/mm/yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime novaValidade))
                {
                    perecivel.DataValidade = novaValidade;
                }
                else
                {
                    Console.WriteLine("Data inválida");
                }
            }

            Console.WriteLine("Produto atualizado!");

        }

        public void ExcluirProduto()
        {
            Console.WriteLine("\nID do produto para excluir:  ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido");
                return;
            }

            var produto = produtos.First(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
                return;
            }

            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!");
        }
    }
}