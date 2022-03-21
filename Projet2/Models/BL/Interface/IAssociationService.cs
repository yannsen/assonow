﻿using Projet2.ViewModels;
using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface IAssociationService
    {
        public int CreateAssociation(AssociationInfoViewModel viewModel, int idRepresentative);

        public void ModifyAssociation(AssociationInfoViewModel viewModel);

        public void DeleteAssociation(int id);

        public List<Association> GetAllAssociations();
    }
}
