namespace SistemaEstoque.Classes
{
    public class ConfigAcessibilidade
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public bool TemaEscuro { get; set; }
        public int FonteTamanho { get; set; } = 9;
        public bool AltoContraste { get; set; }
        public bool LeitorTela { get; set; }
        public bool NavegacaoTeclado { get; set; } = true;
        public bool DescricaoImagens { get; set; }
        public string ContrasteCores { get; set; } = "normal";
    }
}