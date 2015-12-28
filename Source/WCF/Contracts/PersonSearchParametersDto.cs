using System.Runtime.Serialization;

namespace WCF.Contracts
{
    [DataContract]
    public class PersonSearchParametersDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public SexDto? Sex { get; set; }
        [DataMember]
        public int? AgeFrom { get; set; }
        [DataMember]
        public int? AgeTo { get; set; }
        [DataMember]
        public int? HeightFrom { get; set; }
        [DataMember]
        public int? HeightTo { get; set; }
        [DataMember]
        public int? WeightFrom { get; set; }
        [DataMember]
        public int? WeightTo { get; set; }

        public string NationalityTitle { get; set; }
    }
    [DataContract]
    public enum SexDto
    {
        Man = 0,
        Woman
    }
}