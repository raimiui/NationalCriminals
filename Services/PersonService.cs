using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IDocumentService _documentService;
        private readonly IMailService _mailService;

        readonly int _attachmentsCountPerEmail;


        public PersonService(IPersonRepository personRepository, IDocumentService documentService, IMailService mailService)
        {
            _personRepository = personRepository;
            _documentService = documentService;
            _mailService = mailService;

            // how many attachments can be sent per email
            int.TryParse(ConfigurationManager.AppSettings["AttachmentsCountPerEmail"], out _attachmentsCountPerEmail);
        }

        public void Search(PersonSearchParameters personSearchParameters, int maxNumberOfResults, string emailForResults)
        {
            try
            {
                //TODO: this peace wants unit testing!!!

                var persons = _personRepository.Search(personSearchParameters, maxNumberOfResults);
                var attachments = _documentService.PrepareDocuments(persons);

                for (var i = 0; i < attachments.Length / _attachmentsCountPerEmail + 1; i++)
                {
                    var documents = attachments.Skip(i * _attachmentsCountPerEmail).Take(_attachmentsCountPerEmail).ToArray();
                    if (documents.Any())
                        _mailService.Send(emailForResults, documents);
                }
            }
            catch (Exception)
            {
                //TODO: logging
                throw;
            }
        }


        public IList<Person> ReSeed(int count)
        {
            return _personRepository.ReSeed(count);
        }
    }
}
