using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PersonSearchViewModel
    {
        [StringLength(10)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Surname { get; set; }
        [EnumDataType(typeof(Sex))]
        public Sex? Sex { get; set; }

        [Range(10, 100)]
        public int? AgeFrom { get; set; }
        [Range(10, 100)]
        public int? AgeTo { get; set; }

        [Range(40, 250)]
        public int? HeightFrom { get; set; }
        [Range(40, 250)]
        public int? HeightTo { get; set; }

        [Range(10, 500)]
        public int? WeightFrom { get; set; }
        [Range(10, 500)]
        public int? WeightTo { get; set; }

        [StringLength(10)]
        public string NationalityTitle { get; set; }

        [DisplayName("Email for search results")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public enum Sex
    {
        Man = 0,
        Woman
    }
}