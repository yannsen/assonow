using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Projet2.Controllers
{
    public class AdviceController : Controller
    {
        // instantiation pour utilisation ultérieure
        private IAdviceRequestService adviceRequestService;
        private BddContext _bddContext;
        private IAssociationService associationService;
        private IAdviceService adviceService;

        public AdviceController()
        {
            this.adviceRequestService = new AdviceRequestService();
            this.associationService = new AssociationService();
            this.adviceService = new AdviceService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            AdviceRequestListViewModel viewModel = new AdviceRequestListViewModel();
            viewModel.AdviceRequestList = adviceRequestService.GetAllAdviceRequests();
            if(viewModel.AdviceRequestList.Count > 0)
            {
                viewModel.SelectedAdviceRequest = viewModel.AdviceRequestList[0];
                viewModel.Advice = new Advice();
                viewModel.Advice.AdviceSubject = "Réponse à :" + viewModel.SelectedAdviceRequest.AdviceRequestSubject;
            }
            else
            {
                ViewBag.EstVide = true;
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(AdviceRequestListViewModel viewModel)
        {
            viewModel.SelectedAdviceRequest = adviceRequestService.GetAdviceRequest(viewModel.SelectedAdviceRequest.Id);
            viewModel.Advice.AdviceRequestId = viewModel.SelectedAdviceRequest.Id;
            viewModel.Advice.AssociationId = viewModel.SelectedAdviceRequest.AssociationId;
            viewModel.Advice.Date = DateTime.Now;
            viewModel.Advice.MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            viewModel.Advice.IsRead = false;
            if (ModelState.IsValid)
            {
                adviceRequestService.Validate(viewModel.SelectedAdviceRequest.Id);
                adviceService.CreateAdvice(viewModel.Advice);
                return RedirectToAction("Index");
            }
            ModelState.Clear();
            viewModel.AdviceRequestList = adviceRequestService.GetAllAdviceRequests();
            if (viewModel.AdviceRequestList.Count == 0)
            {
                ViewBag.EstVide = true;
            }
            viewModel.Advice = new Advice();
            viewModel.Advice.AdviceSubject = "Réponse à : " + viewModel.SelectedAdviceRequest.AdviceRequestSubject;
            return View(viewModel);
        }

        public IActionResult AskForAdvice(int id)
        {
            AdviceRequest adviceRequest = new AdviceRequest();
            
            adviceRequest.AssociationId = id;
            adviceRequest.Date = DateTime.Now;
            adviceRequest.AssociationName = associationService.GetAssociation(id).Name;
            return View(adviceRequest);
        }

        [HttpPost]
        public IActionResult AskForAdvice(AdviceRequest adviceRequest)
        {
            adviceRequest.Id = 0;
            adviceRequestService.CreateAdviceRequest(adviceRequest);
            return RedirectToAction("AssociationManagement", "AssociationEvent", new { Id = adviceRequest.AssociationId });
        }

        public IActionResult SeeAdvice(int id)
        {
            AdviceListViewModel viewModel = new AdviceListViewModel();
            viewModel.AssociationId = id;
            List<Advice> NewAdvices = adviceService.GetNewAdvice(id);
            List<Advice> ReadAdvices = adviceService.GetReadAdvice(id);
            NewAdvices = NewAdvices.OrderBy(a => a.Date).ToList();
            ReadAdvices = ReadAdvices.OrderBy(a => a.Date).ToList();
            viewModel.Advices = NewAdvices;
            foreach (Advice advice in ReadAdvices)
                viewModel.Advices.Add(advice);
            if (viewModel.Advices.Count == 0)
            {
                ViewBag.EstVide = true;
            }
            else
            {
                adviceService.IsRead(viewModel.Advices[0].Id);
                viewModel.SelectedAdvice = viewModel.Advices[0];
                viewModel.SelectedAdviceRequest = adviceRequestService.GetAdviceRequest(viewModel.Advices[0].AdviceRequestId);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SeeAdvice(AdviceListViewModel viewModel)
        {
            adviceService.IsRead(viewModel.SelectedAdviceId);
            viewModel.SelectedAdvice = adviceService.GetAdvice(viewModel.SelectedAdviceId);
            viewModel.SelectedAdviceRequest = adviceRequestService.GetAdviceRequest(viewModel.SelectedAdvice.AdviceRequestId);
            List<Advice> NewAdvices = adviceService.GetNewAdvice(viewModel.AssociationId);
            List<Advice> ReadAdvices = adviceService.GetReadAdvice(viewModel.AssociationId);
            NewAdvices = NewAdvices.OrderBy(a => a.Date).ToList();
            ReadAdvices = ReadAdvices.OrderBy(a => a.Date).ToList();
            viewModel.Advices = NewAdvices;
            foreach (Advice advice in ReadAdvices)
                viewModel.Advices.Add(advice);
            ModelState.Clear();
            return View(viewModel);
        }
    }
}