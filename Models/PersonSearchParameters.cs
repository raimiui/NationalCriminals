namespace Models
{
    public class PersonSearchParameters
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Sex Sex { get; set; }

        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        
        public int? HeightFrom { get; set; }
        public int? HeightTo { get; set; }

        public int? WeightFrom { get; set; }
        public int? WeightTo { get; set; }
        
        public string NationalityTitle { get; set; }
    }
}