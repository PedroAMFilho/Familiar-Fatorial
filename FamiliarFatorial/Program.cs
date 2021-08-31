using FamiliarFatorial.Domain.DivisorContext.Queries;
using FamiliarFatorial.Domain.DivisorContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamiliarFatorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            string resultMessage;
            bool endApp = false;


            while (!endApp)
            {

                Console.WriteLine("Digite um número (Natural) para decompor.");
                string input = Console.ReadLine();

                while (!int.TryParse(input, out number))
                {
                    Console.Write("Essa não é uma entrada válida, digite um número natural e menor que 2.147.483.647: ");
                    input = Console.ReadLine();
                }


                while (number == 0)
                {
                    Console.WriteLine("Digite um número que não é 0: ");
                    number = Convert.ToInt32(Console.ReadLine());
                }

                if (number != 1)
                {
                    Console.WriteLine("Os divisores do número {0} são :", number);


                    List<GetDivisorsQueryResult> resultValuePrime = Divisor.GetAllDivisorsPrimes(number).ToList();


                    foreach (GetDivisorsQueryResult keyResult in resultValuePrime)
                    {
                        resultMessage = keyResult.Divisor.ToString();
                        resultMessage += keyResult.Prime ? " Primo" : " ";

                        Console.WriteLine(resultMessage);
                    }

                }
                else
                {
                    Console.WriteLine("O divisor do número 1 é 1.");
                }

                Console.Write("Aperte 'x' e Enter para fechar o app, ou aperte qualquer outra tecla e Enter para continuar: ");
                if (Console.ReadLine() == "x") endApp = true;

                Console.WriteLine("\n");
            }
        }

    }
}
