using Microsoft.AspNetCore.Mvc;
using Projet2.Models.BL.Interface;
using System.Linq;

namespace Projet2.Models.BL.Service
{
    public class DocumentService : IDocumentService
    {
        private BddContext _bddContext;
        private IAssociationService associationService;

        public DocumentService()
        {
            _bddContext = new BddContext();
            this.associationService = new AssociationService();
        }

        public void CreateDocument()
        {

        }

        public void DeleteDocument()
        {

        }

        public string GetDocument(int id)
        {
            return _bddContext.Document.FirstOrDefault(d => d.Id == id).Path;
        }

        public string GetAssociationRepresentativeID(int AssociationId)
        {
            var result = _bddContext.Document.Where(d => d.AssociationId == AssociationId).Where(d => d.Type.Equals("ID")).FirstOrDefault();
            if (result == null) return "";
            else return result.Path;
        }

        public string GetOfficialJournalPublication(int AssociationId)
        {
            var result = _bddContext.Document.Where(d => d.AssociationId == AssociationId).Where(d => d.Type.Equals("OfficialJournalPublication")).FirstOrDefault();
            if (result == null) return "";
            else return result.Path;
        }

        public string GetBankDetails(int AssociationId)
        {
            var result = _bddContext.Document.Where(d => d.AssociationId == AssociationId).Where(d => d.Type.Equals("BankDetails")).FirstOrDefault();
            if (result == null) return "";
            else return result.Path;
          
        }
    }
}
