using Projet2.Models.BL.Interface;
using Projet2.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projet2.Models.BL.Service
{
    public class AssociationService : IAssociationService
    {
        private BddContext _bddContext;
        private IAddressService addressService;

        public AssociationService()
        {
            _bddContext = new BddContext();
            this.addressService = new AddressService();
        }

        public int CreateAssociation(AssociationInfoViewModel viewModel, int idRepresentative)
        {
            int idAddress = addressService.CreateAddress(viewModel.Address);
            viewModel.Association.AddressId = idAddress;
            viewModel.Association.AssociationRepresentativeId = idRepresentative;
            if (viewModel.File.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    viewModel.File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    viewModel.Association.Image = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(fileBytes));
                }
            }
            _bddContext.Association.Add(viewModel.Association);
            _bddContext.SaveChanges();
            return viewModel.Association.Id;
        }

        public void ModifyAssociation(AssociationInfoViewModel viewModel)
        {
            addressService.ModifyAddress(viewModel.Address);
            viewModel.Association.AddressId = viewModel.Address.Id;
            _bddContext.Association.Update(viewModel.Association);
            _bddContext.SaveChanges();
        }

        public void DeleteAssociation(int id)
        {
            Association association = _bddContext.Association.Find(id);
            if (association != null)
            {
                addressService.DeleteAddress(association.AddressId);
                _bddContext.Association.Remove(association);
                _bddContext.SaveChanges();
            }
        }
        public List<Association> GetAllAssociations()
        {
            return _bddContext.Association.ToList();
        }
    }
}
