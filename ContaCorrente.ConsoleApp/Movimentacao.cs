
namespace ContaCorrente.ConsoleApp
{
    public class Movimentacao
    {
        public decimal valor;
        public TipoMovimentacao tipo;
        
    }
    public enum TipoMovimentacao
    {
        Debito, Credito
    }
}
