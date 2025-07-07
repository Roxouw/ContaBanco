using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ContaBanco
{
    class ContaBancaria
    {
        public int Numero { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0.0;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial) : this(numero, titular)
        {
            Depositar(depositoInicial);
        }

        public void Depositar(double quantia)
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("O valor do depósito deve ser positivo.");
            }
            Saldo += quantia;
        }

        public void Sacar(double quantia)
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("O valor do saque deve ser positivo.");
            }
            if (Saldo < quantia)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");
            }
            Saldo -= quantia + 5.0; // Taxa de saque de $5.00
        }

        public void OpcaoSwitch(double valor)
        {
            Console.WriteLine("Escolha uma opcao:");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Mostrar dados da conta");
            Console.WriteLine("4 - Sair");
            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o valor a ser depositado: ");
                    double deposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    this.Depositar(deposito);
                    Console.WriteLine("Saldo atualizado: $ ");
                    Console.WriteLine(Saldo);
                    Console.WriteLine();
                    this.OpcaoSwitch(Saldo); // Chama novamente o método para continuar o fluxo
                    break;
                case 2:
                    Console.Write("Digite o valor a ser sacado: ");
                    double saque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    try
                    {
                        this.Sacar(saque);
                        Console.WriteLine("Saldo atualizado: $ ");
                        Console.WriteLine(Saldo);
                        Console.WriteLine();
                        this.OpcaoSwitch(Saldo); // Chama novamente o método para continuar o fluxo
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("Erro ao realizar saque: " + e.Message);
                    }
                    break;
                case 3:
                    Console.WriteLine("Dados da conta:");
                    Console.WriteLine(this);
                    Console.WriteLine();
                    this.OpcaoSwitch(Saldo); // Chama novamente o método para continuar o fluxo
                    break;
                case 4:
                    Console.WriteLine("Saindo do sistema. Obrigado por usar nosso serviço!");
                    return; // Encerra o programa

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        public override string ToString()
        {
            return "Conta "
                + Numero
                + ", Titular: "
                + Titular
                + ", Saldo: $ "
                + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
