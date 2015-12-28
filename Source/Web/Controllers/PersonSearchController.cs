using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Services.Interfaces;
using Web.Models;
using Web.NationalCriminalsWebService;

namespace Web.Controllers
{
    [Authorize]
    public class PersonSearchController : Controller
    {
        private readonly IPersonService _personService;
        private readonly int _maxNumberOfSearchResults;

        public PersonSearchController(IPersonService personService)
        {
            _personService = personService;
            int.TryParse(ConfigurationManager.AppSettings["MaxNumberOfSearchResults"], out _maxNumberOfSearchResults);
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(PersonSearchViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Index", viewModel);

            try
            {
                var personSearchParametersDto = Mapper.Map<PersonSearchParametersDto>(viewModel);
                var personWebServiceClient = new NationalCriminalsWebService.PersonWebServiceClient();
                var passed = personWebServiceClient.Search(personSearchParametersDto, _maxNumberOfSearchResults, viewModel.Email);

                viewModel.SearchWasSuccessful = passed;
                if(passed)
                
                    return View(viewModel);

                return View("Error");
            }
            catch
            {
                //TODO: logging...
                return View("Error");
            }
        }

        public void ReSeedDb(int count = 20)
        {
            var persons = _personService.ReSeed(count);
        }
    }
}
