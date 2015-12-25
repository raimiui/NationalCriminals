using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public virtual Nationality Nationality { get; set; }
    }

    public enum Sex
    {
        Man = 0,
        Woman
    }
}
