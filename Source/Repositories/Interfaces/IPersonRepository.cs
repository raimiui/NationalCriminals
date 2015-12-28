using System.Collections.Generic;
using Models;

namespace Repositories.Interfaces
{
    public interface IPersonRepository
    {
        IList<Person> ReSeed(int count);

        IList<Person> Search(PersonSearchParameters psp, int maxNumberOfResults);
    }
}