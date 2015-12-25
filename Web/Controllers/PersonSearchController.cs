using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Interfaces;
using Web.Models;
using Web.NationalCriminalsWebService;

namespace Web.Controllers
{
    public class PersonSearchController : Controller
    {
        private readonly IPersonService _personService;

        public PersonSearchController(IPersonService personService)
        {
            _personService = personService;
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
                var personWebServiceClient = new NationalCriminalsWebService.PersonWebServiceClient();
                var passed = personWebServiceClient.Search(new PersonSearchParametersDto { AgeFrom = 2 }, 7, viewModel.Email);

                if(passed)
                    return RedirectToAction("Index");

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
