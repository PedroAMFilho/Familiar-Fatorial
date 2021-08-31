using FamiliarFatorial.Domain.DivisorContext.Entities;
using FamiliarFatorial.Domain.DivisorContext.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FamiliarFatorial.Api.Controllers.DivisorContext
{
    public class DivisorController : Controller
    {
        /// <summary>
        /// Retorna uma lista contendo os divisores e se são primos.
        /// </summary>
        /// <param name="number">Número para decompor</param>
        /// <returns>Objeto contendo o divisor e se é primo.</returns>
        [HttpGet]
        [Route("familiarfatorial/{number:int}")]
        public IEnumerable<GetDivisorsQueryResult> GetDivisorsPrime(int number){
            return Divisor.GetAllDivisorsPrimes(number);
        }
    }
}
