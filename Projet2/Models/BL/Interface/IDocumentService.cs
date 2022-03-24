namespace Projet2.Models.BL.Interface
{
    public interface IDocumentService 
    {
        public void CreateDocument();

        public void DeleteDocument();

        public string GetDocument(int id);

        public string GetAssociationRepresentativeID(int AssociationId);

        public string GetOfficialJournalPublication(int AssociationId);

        public string GetBankDetails(int AssociationId);
    }
}
