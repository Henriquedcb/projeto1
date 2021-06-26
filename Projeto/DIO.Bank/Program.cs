using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObeterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;                    
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;                    
                    case "5":
                        Depositar();
                        break;                    
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObeterOpcaoUsuario();
                
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();

        }

        private static void Transferir()
        {
            Console.WriteLine();
            Console.Write("Digite um número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            while(indiceContaOrigem != listContas.Count && indiceContaOrigem < 0)
            {
                Console.Write("Digite um número da conta de origem: ");
                indiceContaOrigem = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.Write("Digite um número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            while(indiceContaDestino != listContas.Count && indiceContaDestino < 0)
            {
                Console.Write("Digite um número da conta de destino: ");
                indiceContaDestino = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.Write("Digite um valor a ser transferido: R$");
            double valorTransferencia = double.Parse(Console.ReadLine());
            while(valorTransferencia < 0)
            {
                Console.Write("Digite um valor a ser transferido maior que R$0.00: R$");
                valorTransferencia = double.Parse(Console.ReadLine());
            }

            Console.WriteLine();            
            Console.WriteLine("Operação realizada com sucesso");
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
            Console.WriteLine();
            Console.WriteLine("Situação das contas atualizada");
            Console.WriteLine($"{listContas[indiceContaOrigem]}");
            Console.WriteLine($"{listContas[indiceContaDestino]}");
        }

        private static void Sacar()
        {
            Console.WriteLine();
            Console.Write("Digite um número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            while(indiceConta != listContas.Count && indiceConta < 0)
            {
                Console.Write("Digite um número da conta válido: ");
                indiceConta = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.Write("Digite o valor a ser sacado: R$");
            double valorSaque = double.Parse(Console.ReadLine());
            while (valorSaque <= 0)
            {
                Console.WriteLine("Valor Inválido, Tente um valor maior que R$0.00: ");
                valorSaque = double.Parse(Console.ReadLine());
            }

            Console.WriteLine();            
            Console.WriteLine("Operação realizada com sucesso");
            listContas[indiceConta].Sacar(valorSaque);
            Console.WriteLine();
            Console.WriteLine("Situação da conta atualizada");
            Console.WriteLine($"{listContas[indiceConta]}");             
        }

        private static void Depositar()
        {
            Console.WriteLine();
            Console.Write("Digite um número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            while(indiceConta != listContas.Count && indiceConta < 0)
            {
                Console.Write("Digite um número da conta válido: ");
                indiceConta = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.Write("Digite o valor a ser depositado: R$");
            double valorDeposito = double.Parse(Console.ReadLine());
            while (valorDeposito <= 0)
            {
                Console.WriteLine("Valor Inválido, Tente um valor maior que R$0.00");
                valorDeposito = double.Parse(Console.ReadLine());
            }
            
            Console.WriteLine();            
            Console.WriteLine("Operação realizada com sucesso");
            listContas[indiceConta].Depositar(valorDeposito);
            Console.WriteLine();
            Console.WriteLine("Situação da conta atualizada");
            Console.WriteLine($"{listContas[indiceConta]}");
        }

        private static void InserirConta()
        {
            Console.WriteLine();
            Console.WriteLine("Inserindo nova conta");
            Console.WriteLine("Por favor preecha as seguintes informações");
            
            Console.WriteLine();
            Console.Write("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            while(entradaTipoConta != 1 && entradaTipoConta != 2)
            {
                Console.Write("Valor Inválido. Digite uma valor válido: ");
                entradaTipoConta = int.Parse(Console.ReadLine());
            }
            
            Console.WriteLine();
            Console.Write("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Digite o saldo inicial: R$");
            double entradaSaldo = double.Parse(Console.ReadLine());
            while(entradaSaldo <= 0)
            {
                Console.Write("Digite um saldo maior que R$0.00: R$");
                entradaSaldo = double.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.Write("Digite o limite de crédito: R$");
            double entradaCredito = double.Parse(Console.ReadLine());
            while(entradaCredito <= 0)
            {
                Console.Write("Digite o limite de crédito maior que R$0.00: R$");
                entradaCredito = double.Parse(Console.ReadLine());
            }

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);
            Console.WriteLine();
            Console.WriteLine("Conta cadastrada com sucesso");
            Console.WriteLine("Contas cadatradas");
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write($"<<{ i }>> . ");
                Console.WriteLine(conta);
                Console.WriteLine();
            }

        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista de Contas Cadastradas");
            Console.WriteLine();

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.WriteLine("Escolha a opção de número 2 para cadastrar uma conta!");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write($"<<{ i }>> . ");
                Console.WriteLine(conta);
                Console.WriteLine();
            }
        }

        private static string ObeterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            Console.Write("Qual a sua opção: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
