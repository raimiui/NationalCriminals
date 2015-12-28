using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Models;

namespace Services.Interfaces
{
    public interface IPersonService
    {
        void Search(PersonSearchParameters personSearchParameters, int maxNumberOfResults, string emailForResults);
        IList<Person> ReSeed(int count);
    }
}