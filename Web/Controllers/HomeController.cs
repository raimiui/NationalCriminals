using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Services;
using Services.Interfaces;
using Web.NationalCriminalsWebService;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public ActionResult Index()
        {

            var personWebServiceClient = new NationalCriminalsWebService.PersonWebServiceClient();
            var succeeded = personWebServiceClient.Search(new PersonSearchParametersDto { AgeFrom = 2 }, 7, "sss@asd.com");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void ReSeed(int count = 20)
        {
            var persons = _personService.ReSeed(count);
        }
    }
}