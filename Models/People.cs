using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ViewModels.Models
{
    public class People
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }

    public class Persons : People
    { 
        public IList<People> data { get; set; }
        public Persons() : base() {
            data = new List<People>();
        }
       


    }

    public class SearchPersons : Persons
    {
        private Persons _items = new Persons();

        public IList<People> Search(string searchString)
        {
            return this._items.data;
        }
    }

    public class DeletePersons : Persons
    {
        private Persons _items = new Persons();

        public IList<People> Delete(int id)
        {
            return this._items.data;
        }
    }

    public static class DataModel
    {
        public static Persons GetData()
        {
            using (StreamReader r = new StreamReader(Environment.CurrentDirectory + "/Data/PeopleList.json"))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<Persons>(json);
               
                return items;
            }
        }

        public static Persons GetTempData()
        {
            try
            {
                using (StreamReader r = new StreamReader(Environment.CurrentDirectory + "/Data/PeopleListTemp.json"))
                {
                    string json = r.ReadToEnd();


                    if (json.Length < 1)
                    {
                        ResetData();
                        json = r.ReadToEnd();
                    }
                    var items = JsonConvert.DeserializeObject<Persons>(json);

                    return items;
                }
            }
            catch (Exception ex)
            {
                ResetData();

                using (StreamReader r = new StreamReader(Environment.CurrentDirectory + "/Data/PeopleListTemp.json"))
                {
                    string json = r.ReadToEnd();

                    var items = JsonConvert.DeserializeObject<Persons>(json);

                    return items;
                }
            }
        }

        public static async void Delete(int id)
        {
            var ret = DataModel.GetTempData();

            ret.data.RemoveAt(id);

            await DataModel.WriteTempData(ret);
        }

        public static async void Add(People person)
        {
            var ret = DataModel.GetTempData();

            ret.data.Add(person);

            await DataModel.WriteTempData(ret);
        }

        public static Persons Search(string searchString)
        {
            var tmp = DataModel.GetTempData();

            Persons ret = new Persons();
            People p = new People();
            
            for(int i = 0; i < tmp.data.Count; i++)
            {
                if( tmp.data[i].Name.Contains(searchString) || tmp.data[i].City.Contains(searchString))
                {
                    p.City = tmp.data[i].City;
                    p.Name = tmp.data[i].Name;
                    p.Phone = tmp.data[i].Phone;
                    ret.data.Add(p);
                    p = new People();
                }
            }

            return ret;
        }

        public static async Task WriteTempData(Persons data)
        {
            string json = JsonConvert.SerializeObject(data);

            await File.WriteAllTextAsync(Environment.CurrentDirectory + "/Data/PeopleListTemp.json", json);
        }

        public static async Task ResetData()
        {
            await WriteTempData(GetData());
        }
    }
}
