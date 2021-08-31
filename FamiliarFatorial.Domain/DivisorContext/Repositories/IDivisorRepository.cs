using System.Collections.Generic;

namespace FamiliarFatorial.Domain.DivisorContext.Commands.Repositories
{
    public interface IDivisorRepository
    {
        Dictionary<int, bool> GetAllDivisorsPrimes(int number);
    }
}
