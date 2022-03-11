using System;

namespace ContaCorrente.ConsoleApp
{
    
    public class Conta
    {
        public Movimentacao[] movimentacoes;
        public Cliente cliente = new Cliente();
        public double saldo;
        public int numero;
        public bool statusEspecial;
        public double limite;
        int contadorMovimentacoes = 0;
       

        public void Sacar(int valor)
        {
            Movimentacao novaMovimentacao = new Movimentacao();
            switch (statusEspecial)
            {
                case true:

                    if (valor <= (limite + saldo))
                    {
                        saldo = saldo - valor;

                        novaMovimentacao.valor = valor;
                        novaMovimentacao.tipo = TipoMovimentacao.Debito;


                        for (int i = 0; i < movimentacoes.Length; i++)
                        {
                            if (i == contadorMovimentacoes)
                            {
                                movimentacoes[i] = novaMovimentacao;

                            }
                        }

                        contadorMovimentacoes++;

                    }

                    break;
                case false:

                    if(valor < saldo)
                    {
                        saldo = saldo - valor;
                        
                    }
                    novaMovimentacao.valor = valor;
                    novaMovimentacao.tipo = TipoMovimentacao.Debito;


                    for (int i = 0; i < movimentacoes.Length; i++)
                    {
                        if (i == contadorMovimentacoes)
                        {
                            movimentacoes[i] = novaMovimentacao;

                        }
                    }

                    contadorMovimentacoes++;

                    break;
            }

        }

        public void ExibirExtrato()
        {
            Console.WriteLine();
            Console.WriteLine("----------DADOS DA CONTA----------");
            Console.WriteLine("Cliente: {0}", cliente.nome);
            Console.WriteLine("Nº da conta: {0}", numero);
            Console.WriteLine("Saldo: R$ {0}", saldo);
            Console.WriteLine("Limite: {0}", limite);
            Console.WriteLine("Conta especial: {0}", statusEspecial == true ? "Sim" : "Não");
            Console.WriteLine("-------------EXTRATO--------------");

            for (int i = 0; i < contadorMovimentacoes; i++)
            {
                Console.WriteLine("\nValor da movimentação: " + movimentacoes[i].valor.ToString());
               Console.WriteLine("Tipo de movimentação: "+ movimentacoes[i].tipo.ToString());
            }
            Console.WriteLine("----------------------------------");

        }

        public void Depositar(int valor)
        {
            Movimentacao novaMovimentacao = new Movimentacao();
            saldo += valor;

            novaMovimentacao.valor = valor;
            novaMovimentacao.tipo = TipoMovimentacao.Credito;
            for (int i = 0; i < movimentacoes.Length; i++)
            {
                if (i == contadorMovimentacoes)
                {
                    movimentacoes[i] = novaMovimentacao;

                }
            }

            contadorMovimentacoes++;

        }
        public void TransferirPara(Conta contaDestino, int valor)
        {
            Movimentacao movimentacaoDestinataria = new Movimentacao();
            Movimentacao movimentacaoRemetente = new Movimentacao();



            if (valor <= (limite + saldo))
            {
                saldo = saldo - valor;
                contaDestino.saldo += valor;

                contaDestino.Depositar(valor);
                movimentacaoRemetente.valor = valor;
                movimentacaoRemetente.tipo = TipoMovimentacao.Debito;

                movimentacaoDestinataria.valor = valor;
                movimentacaoDestinataria.tipo = TipoMovimentacao.Credito;

                for (int i = 0; i < movimentacoes.Length; i++)
                {
                    if (i == contadorMovimentacoes)
                    {
                        movimentacoes[i] = movimentacaoRemetente;

                    }
                }
                for(int i = 0;i < contaDestino.movimentacoes.Length; i++)
                {
                    if(i == contaDestino.contadorMovimentacoes)
                    {
                        contaDestino.movimentacoes[i] = movimentacaoDestinataria;
                        
                    }
                }
            }
            contadorMovimentacoes++;
            contaDestino.contadorMovimentacoes++;


        }
        
    }
}
