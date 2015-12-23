using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Nationality Nationality { get; set; }
    }

    public enum Sex
    {
        Man = 0,
        Woman
    }
}
