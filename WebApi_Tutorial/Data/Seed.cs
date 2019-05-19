using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Tutorial.Models;

namespace WebApi_Tutorial.Data
{
    /// <summary>
    /// Json-ból beolvasni elsőfuttatás alkalmával az összes személy-t
    /// </summary>
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void SeedPersons()
        {
            var personData = System.IO.File.ReadAllText("C:\\Users\\Molnár Attila\\source\\repos\\WebApi_Tutorial\\WebApi_Tutorial\\Data\\PersonSeedData.json");
            var persons = JsonConvert.DeserializeObject<List<Person>>(personData);

            foreach (var person in persons)
            {
                dataContext.People.Add(person);
            }
            dataContext.SaveChanges();
        }
    }
}
