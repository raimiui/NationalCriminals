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
        public PersonRepository()
            : base("name=DefaultConnection")
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
    }
}
