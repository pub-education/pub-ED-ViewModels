using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Models;
using ViewModels.Models.ViewModels;

namespace ViewModels.Controllers
{
    public class PeopleController : Controller
    {
        public ViewResult Details()
        {
            People people = new People();

            PeopleDetailsViewModel peopleDetailsViewModel = new PeopleDetailsViewModel()
            {
                People = people,
                Title = "People Details List",
                Header = "People Details"
            };

            return View(peopleDetailsViewModel);
        }

        public ViewResult Search(string searchString)
        {

            DataModel.Search(searchString);


            PeopleSearchViewModel peopleSearchViewModel = new PeopleSearchViewModel()
            {
                DataList = DataModel.Search(searchString),
                Title = "People Search List",
                Header = "People Search"
            };

            return View(peopleSearchViewModel);
        }

        public ViewResult Add(People person) { 

            DataModel.Add(person);

            PeopleDetailsViewModel peopleDetailsViewModel = new PeopleDetailsViewModel()
            {
                //People = people,
                Title = "People Details List",
                Header = "People Details"
            };

            return View("Details", peopleDetailsViewModel);
        }

        public ViewResult Delete(string Id)
        {
            int id = Convert.ToInt32(Id);

            DataModel.Delete(id);

            PeopleDetailsViewModel peopleDetailsViewModel = new PeopleDetailsViewModel()
            {
                //People = people,
                Title = "People Details List",
                Header = "People Details",
                Id = id
            };
            return View("Details", peopleDetailsViewModel);
        }
    }
}
