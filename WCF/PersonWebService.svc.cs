using System.Threading.Tasks;
using AutoMapper;
using Models;
using Services.Interfaces;
using WCF.Contracts;

namespace WCF
{
    public class PersonWebService : IPersonWebService
    {
        private readonly IPersonService _personService;

        public PersonWebService(IPersonService personService)
        {
            _personService = personService;
        }

        public bool Search(PersonSearchParametersDto personSearchParameters, int maxNumberOfResults, string emailForResults)
        {
            if (!IsValid(personSearchParameters, maxNumberOfResults, emailForResults))
                return false; //TODO: return validation messages in response

            Task.Run(() => _personService.Search(Mapper.Map<PersonSearchParameters>(personSearchParameters), maxNumberOfResults, emailForResults));
            return true;
        }

        #region private methods

        private bool IsValid(PersonSearchParametersDto personSearchParameters, int maxNumberOfResults, string emailForResults)
        {
            //TODO: VALIDATE! 
            // The service exposed method only validates the parameters and immediately returns true/false. 
            // After that it launches a background thread to process and mail the results.
            return true;
        }

        #endregion private methods
    }
}
