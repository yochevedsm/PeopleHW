using Microsoft.AspNetCore.Mvc;
using PeopleHW.web.Models;
using System.Collections.Generic;
using PeopleHW.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;



namespace PeopleHW.web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
             "Data Source=.\\sqlexpress;Initial Catalog=Loan HW ;Integrated Security=True";


        public IActionResult Index()
        {
           PeopleDB db = new PeopleDB(_connectionString);
           PersonViewModel vm = new PersonViewModel
            {
                people = db.GetPeople()
            };
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(List<Person> people)
        {
            PeopleDB db = new(_connectionString);
            foreach (var person in people)
            {
                db.AddPerson(person);
            }


            TempData["message"] = "People added successfully";
            return Redirect("/");
        }
    }
}
