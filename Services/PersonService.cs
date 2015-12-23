using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories;
using Services.Interfaces;

namespace Services
{
    public class PersonService : IPersonService
    {
        public IList<Person> Search()
        {
            var personRepository = new PersonRepository();

            var nationality = new Nationality { Title = "The irish", Description = "Description for irish " };

            personRepository.Persons.Add(new Person
            {
                Sex = Sex.Man,
                Age = 21,
                Name = "Rupert",
                Surname = "TheDeer"
                ,
                Nationality = nationality

            });
            personRepository.SaveChanges();

            return personRepository.Persons.ToList();
        }
    }
}
