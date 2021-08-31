using FamiliarFatorial.Domain.DivisorContext.Queries;
using System.Collections.Generic;

namespace FamiliarFatorial.Domain.DivisorContext.Entities
{
    public static class Divisor
    {
        public static IEnumerable<GetDivisorsQueryResult> GetAllDivisorsPrimes(int number)
        {
            List<GetDivisorsQueryResult> resultValuePrime = new(){ };

            if (number == 0)
            {
                return resultValuePrime;
            }

            resultValuePrime.Add(new GetDivisorsQueryResult() { Divisor = 1, Prime = false });
            if (number == 1)
            {
                return resultValuePrime;
            }

            for (int divisor = 2; divisor <= (number / 2); divisor++)
            {
                if ((number % divisor) == 0)
                {
                    resultValuePrime.Add(new GetDivisorsQueryResult() { Divisor = divisor, Prime = IsPrimeNumber(divisor) });
                }
            }

            resultValuePrime.Add(new GetDivisorsQueryResult() { Divisor = number, Prime = IsPrimeNumber(number) });

            return resultValuePrime;
        }



        public static bool IsPrimeNumber(int number)
        {
            bool prime = true;
            int fator = number / 2;
            int i = 0;
            for (i = 2; i <= fator; i++)
            {
                if ((number % i) == 0)
                    prime = false;
            }
            return prime;
        }
    }
}
