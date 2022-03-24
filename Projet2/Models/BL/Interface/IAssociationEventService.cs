﻿using Projet2.ViewModels;
using System;
using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface IAssociationEventService // : IDisposable
    {
        public int CreateAssociationEvent(AssociationEventInfoViewmodel viewModel, int memberID);
        public void ModifyAssociationEvent(AssociationEventInfoViewmodel viewModel);
        public void DeleteAssociationEvent(int associationEventId);

        public List<Association> AssociationsRepresentative(int MemberConnectedId);
    }
}