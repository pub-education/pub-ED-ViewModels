using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Models;


namespace ViewModels.Models.ViewModels
{
    public class PeopleDetailsViewModel
    {
        public People People { get; set; }

        public string Title { get; set; }
        public string Header { get; set; }

        public int Id { get; set; }

        public string SearchString { get; set; }

        public People PeopleData { get; set; }

        public Persons ListData { get
            {
                return DataModel.GetTempData();
            } 
        }

        /* public Persons Delete
         {
             get
             {
                 return DataModel.Delete(Id);
             }
         }

         public Persons Search { get
             {
                 return DataModel.Search(SearchString);
             } 
         }

         public Persons Add { get
             {
                 return DataModel.Add(PeopleData);
             } }
        */
    }
}
