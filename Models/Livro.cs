namespace UC17.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string? Título { get; set; }

        public int QuantidadePaginas { get; set; }

        public bool Disponível { get; set; }
    }
}
