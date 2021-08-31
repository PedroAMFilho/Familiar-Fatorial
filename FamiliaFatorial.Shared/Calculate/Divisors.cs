using System.Collections.Generic;

namespace FamiliarFatorial.Shared.Calculate
{
    public static class Divisors
    {
        public static Dictionary<int, bool> GetAllDivisorsPrimes(int number){
            Dictionary<int, bool> resultValuePrime = new();

            if (number == 0){
                return resultValuePrime;
            }

            resultValuePrime.Add(1, false);
            if (number == 1){
                return resultValuePrime;
            }

            for (int divisor = 2; divisor <= (number / 2); divisor++)
            {
                if ((number % divisor) == 0)
                {
                    resultValuePrime.Add(divisor, IsPrimeNumber(divisor));
                }
            }

            resultValuePrime.Add(number, IsPrimeNumber(number));

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
