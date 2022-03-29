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

        public int CreateDocument(Document document)
        {
            _bddContext.Document.Add(document);
            _bddContext.SaveChanges();
            return document.Id;
        }

        public void DeleteDocument(int id)
        {
            _bddContext.Document.Remove(GetDocument(id));
            _bddContext.SaveChanges();
        }

        public Document GetDocument(int id)
        {
            return _bddContext.Document.Find(id);
        }

        public string GetAssociationRepresentativeIDPath(int associationId)
        {
            var result = _bddContext.Document.Where(d => d.AssociationId == associationId).Where(d => d.Type.Equals("ID")).FirstOrDefault();
            if (result == null) return "";
            else return result.Path;
        }

        public string GetOfficialJournalPublicationPath(int associationId)
        {
            var result = _bddContext.Document.Where(d => d.AssociationId == associationId).Where(d => d.Type.Equals("OfficialJournalPublication")).FirstOrDefault();
            if (result == null) return "";
            else return result.Path;
        }

        public string GetBankDetailsPath(int associationId)
        {
            var result = _bddContext.Document.Where(d => d.AssociationId == associationId).Where(d => d.Type.Equals("BankDetails")).FirstOrDefault();
            if (result == null) return "";
            else return result.Path;
          
        }

        public Document GetBankDetails(int associationId)
        {
            return _bddContext.Document.FirstOrDefault(d => d.AssociationId == associationId && d.Type == "BankDetails");
        }

        public Document GetOfficialJournalPublication(int associationId)
        {
            return _bddContext.Document.FirstOrDefault(d => d.AssociationId == associationId && d.Type == "OfficialJournalPublication");
        }

        public Document GetAssociationRepresentativeID(int associationId)
        {
            return _bddContext.Document.FirstOrDefault(d => d.AssociationId == associationId && d.Type == "ID");
        }
    }
}
