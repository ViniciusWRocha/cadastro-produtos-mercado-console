namespace MercadoConsole_POO.Models
{
    public interface IProduto
    {
        int Id { get; set; }
        string Nome { get; set; }
        decimal Price { get; set; }
        string Descricao();

    }
}
