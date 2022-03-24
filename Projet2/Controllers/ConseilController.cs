using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;
using System;
using System.Collections.Generic;

namespace Projet2.Controllers
{
    public class ConseilController : Controller
    {
        // instantiation pour utilisation ultérieure
        private IAdviceRequestService adviceRequestService;

        BddContext _bddContext;

        public ConseilController()
        {
            this.adviceRequestService = new AdviceRequestService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            AdviceRequestViewModel viewModel = new AdviceRequestViewModel();
            viewModel.AdviceRequestList = adviceRequestService.GetAllAdviceRequests();
            return View(viewModel);
        }
    }
}











//public IActionResult Index()
//{

//    Advice nouveauConseil = new Advice
//    {
//        Id = 2,
//        AdviceSubject = "CONSEIL DEUX ",
//        AdviceText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam",
//        Date = new DateTime(2022, 02, 01),
//        AdviceRequestId = 2,
//        MemberId = 1
//    };

//    AdviceViewModel avm = new AdviceViewModel
//    {
//        Advice = nouveauConseil
//    };

//    return View(avm);


//}
