using Projet2.ViewModels;
using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface IAssociationService
    {
        public int CreateAssociation(AssociationInfoViewModel viewModel, int idRepresentative);

        public void ModifyAssociation(Association association);

        public void ModifyAssociationViewModel(AssociationInfoViewModel viewModel);

        public void DeleteAssociation(int id);

        public Association GetAssociation(int id);

        public List<Association> GetAllAssociations();

        public List<Association> GetUnpublishedAssociations();

        public List<AssociationSelectViewModel> GetAssociationSelectList();

        public void ValidateAssociation(int id);

        public Association GetAssociationByDonationId(int id);

        public Association GetAssociationByFundraisingId(int id);

        public List<Association> GetHighlightedAssociations();

        public List<Association> GetNotHighlightedAssociations();

        public int GetContribution(int id);

        public Association GetAssociationByContributionId(int id);

        public List<Association> GetAssociationsToSearch(ListSearchAssociationViewModel viewModel);
    }
}
