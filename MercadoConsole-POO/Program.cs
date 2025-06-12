using MercadoConsole_POO.Services;

ProdutoService servico = new ProdutoService();
bool continuar = true; 

while (continuar)
{
    Console.Clear();
    Console.WriteLine("=== Sistema de Mercado ===");
    Console.WriteLine("1. Listar Produtos" +
        "\n2. Adicionar Produto" +
        "\n3. Atualizar Produto" +
        "\n4. Excluir Produto" +
        "\n5. Sair" +
        "\nOpção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1": servico.ListarProduto(); break;
        case "2": servico.AdicionarProduto(); break;
        case "3": servico.AtualizarProduto(); break;
        case "4": servico.ExcluirProduto(); break;
        case "5": continuar =false; break;
        default: Console.WriteLine("Opção inválida");break;
    }

    if (continuar)
    {
        Console.WriteLine("\nPrecione qualquer tecla para continuar");
        Console.ReadKey();
    }

}