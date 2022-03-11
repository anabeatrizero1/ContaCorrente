using System;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conta conta1 = new Conta();
            conta1.cliente.nome = "Conde Drácula";
            conta1.saldo = 1000;
            conta1.numero = 12423;
            conta1.limite = 0;
            conta1.statusEspecial = true;
            conta1.movimentacoes = new Movimentacao[10];

            conta1.Sacar(200);

            conta1.Depositar(300);

            conta1.Depositar(500);

            conta1.Sacar(200);

            Conta conta2 = new Conta();
            conta2.cliente.nome = "";
            conta2.saldo = 300;
            conta2.numero = 13;
            conta2.limite = 0;
            conta2.statusEspecial = true;
            conta2.movimentacoes = new Movimentacao[10];

            conta1.TransferirPara(conta2, 400);

            conta1.ExibirExtrato();
            conta2.ExibirExtrato();
            Console.ReadKey();


        }
    }
}
