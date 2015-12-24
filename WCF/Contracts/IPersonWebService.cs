using System.ServiceModel;

namespace WCF.Contracts
{
    [ServiceContract]
    public interface IPersonWebService
    {
        [OperationContract]
        bool Search(PersonSearchParametersDto personSearchParameters, int maxNumberOfResults, string emailForResults);
    }
}
