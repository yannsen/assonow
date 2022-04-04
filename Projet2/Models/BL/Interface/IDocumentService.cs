namespace Projet2.Models.BL.Interface
{
    public interface IDocumentService 
    {
        public int CreateDocument(Document document);

        public void DeleteDocument(int id);

        public Document GetDocument(int id);

        public string GetAssociationRepresentativeIDPath(int associationId);

        public string GetOfficialJournalPublicationPath(int associationId);

        public string GetBankDetailsPath(int associationId);

        public Document GetBankDetails(int associationId);

        public Document GetOfficialJournalPublication(int associationId);

        public Document GetAssociationRepresentativeID(int associationId);
    }
}
