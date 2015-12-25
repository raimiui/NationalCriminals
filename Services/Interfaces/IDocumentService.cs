using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IDocumentService
    {
        Document[] PrepareDocuments(IList<Person> persons);
    }
}