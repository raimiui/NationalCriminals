using System.Collections.Generic;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Search(PersonSearchParameters personSearchParameters, int maxNumberOfResults, string emailForResults)
        {
            var persons = _personRepository.Search(personSearchParameters, maxNumberOfResults);
            //TODO:
            /*
             * Prepares found criminal profiles as PDF files (one person per file)
             * Email the files to the recipient (maximum 10 files per email, so could be multiple emails).
             */
        }

        public IList<Person> ReSeed(int count)
        {
            return _personRepository.ReSeed(count);
        }
    }
}
