using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Models;
using Repositories.Interfaces;


namespace Repositories
{
    public class PersonRepository : DbContext, IPersonRepository
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        
        public PersonRepository()
            : base("name=DefaultConnection")
        {
        }

        public IList<Person> ReSeed(int count)
        {
            Persons.RemoveRange(Persons.ToList());
            Nationalities.RemoveRange(Nationalities.ToList());
            SaveChanges();

            Nationalities.AddRange(CreateNationalities());
            Persons.AddRange(CreatePersons(count));
            SaveChanges();

            return Persons.ToList();
        }

        #region ReSeed() private stuff

        private readonly Random _rnd = new Random();

        private IEnumerable<Nationality> CreateNationalities()
        {
            return new[]
            {
                new Nationality {Title = "Irish"},
                new Nationality {Title = "English"},
                new Nationality {Title = "Dutch"},
                new Nationality {Title = "Italian"}
            };
        }
        private IEnumerable<Person> CreatePersons(int count)
        {
            var persons = new List<Person>();
            for (var i = 0; i < count; i++)
            {
                var rand = _rnd.Next(1000);
                persons.Add(new Person
                {
                    Name = "Name " + rand,
                    Surname = "Surname " + rand,
                    Sex = (Sex)_rnd.Next(2),
                    Age = _rnd.Next(1, 100),
                    Height = _rnd.Next(0, 300),
                    Weight = _rnd.Next(0, 200),
                    Nationality = Nationalities.Local.OrderBy(n => n.Id).Skip(_rnd.Next(Nationalities.Local.Count()) - 1).First()
                });
            }
            return persons;
        }

        #endregion ReSeed() private stuff

        public IList<Person> Search(PersonSearchParameters psp, int maxNumberOfResults)
        {
            var persons =
                Persons
                    .Where
                    (p =>
                        (string.IsNullOrEmpty(psp.Name) || p.Name.Contains(psp.Name))
                        &&
                        (string.IsNullOrEmpty(psp.Surname) || p.Surname.Contains(psp.Surname))
                        &&
                        (!psp.Sex.HasValue || p.Sex == psp.Sex)
                        &&
                        (!psp.AgeFrom.HasValue || psp.AgeFrom <= p.Age)
                        &&
                        (!psp.AgeTo.HasValue || p.Age <= psp.AgeTo)
                        &&
                        (!psp.HeightFrom.HasValue || psp.HeightFrom <= p.Height)
                        &&
                        (!psp.HeightTo.HasValue || p.Height <= psp.HeightTo)
                        &&
                        (!psp.WeightFrom.HasValue || psp.WeightFrom <= p.Weight)
                        &&
                        (!psp.WeightTo.HasValue || p.Weight <= psp.WeightTo)
                        &&
                        (string.IsNullOrEmpty(psp.NationalityTitle) || p.Nationality.Title.Contains(psp.NationalityTitle))
                     )
                    .Take(maxNumberOfResults)
                    .ToList();

            return persons;
        }
    }
}