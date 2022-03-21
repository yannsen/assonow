using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.ViewModels;
using System.Collections.Generic;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;

namespace Projet2.Controllers
{
    public class HomeController : Controller
    {
        private IAssociationService associationService;

        BddContext _bddContext;
        public HomeController()
        {
            this.associationService = new AssociationService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            List<AssociationInfoViewModel> associationAddressListViewModel = new List<AssociationInfoViewModel>();
            BddContext _bddContext = new BddContext();
            foreach (var association in associationService.GetAllAssociations())
            {
                Address address = _bddContext.Address.Find(association.AddressId);
                associationAddressListViewModel.Add(new AssociationInfoViewModel { Address = address, Association = association});
            }
            return View(associationAddressListViewModel);
        }
    }
}
