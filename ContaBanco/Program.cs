using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ContaBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta;

            Console.WriteLine("Bem-vindo ao sistema de gerenciamento de contas bancárias!");
            // Aqui você pode adicionar a lógica para gerenciar contas bancárias
            // Por exemplo, criar uma conta, depositar, sacar, etc.
            Console.WriteLine();

            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do titular da conta: ");
            string titular = Console.ReadLine();

            Console.Write("Deseja iniciar com um saldo? (s/n): ");
            char resposta = char.Parse(Console.ReadLine().ToLower());
            if (resposta == 's')
            {
                Console.Write("Digite o saldo inicial: ");
                double saldoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numero, titular, saldoInicial);
            }
            else
            {
                conta = new ContaBancaria(numero, titular);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta);

            Console.WriteLine();

            conta.OpcaoSwitch(conta.Saldo); // Chama o método OpcaoSwitch com valor 0 para evitar erro de compilação

        }
    }
}