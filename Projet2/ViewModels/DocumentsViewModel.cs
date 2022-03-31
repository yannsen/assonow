using Microsoft.AspNetCore.Http;

namespace Projet2.ViewModels
{
    public class DocumentsViewModel
    {
        public int AssociationId { get; set; }

        public IFormFile RepresentativeID { get; set; }

        public IFormFile BankDetails { get; set; }

        public IFormFile OfficialJournalPublication { get; set; }

        public string FormerOfficialJournalPublication { get; set; }

        public string FormerRepresentativeID { get; set; }

        public string FormerBankDetails { get; set; }
    }
}
